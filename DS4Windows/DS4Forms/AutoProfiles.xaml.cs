using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Ookii.Dialogs.Wpf;
using DS4WinWPF.DS4Forms.ViewModels;
using Microsoft.Win32;
using DS4Windows;
using System.Windows.Data;

namespace DS4WinWPF.DS4Forms
{
    /// <summary>
    /// Interaction logic for AutoProfiles.xaml
    /// </summary>
    public partial class AutoProfiles : UserControl
    {
        protected String m_Profile = Global.appdatapath + "\\Auto Profiles.xml";
        public const string steamCommx86Loc = @"C:\Program Files (x86)\Steam\steamapps\common";
        public const string steamCommLoc = @"C:\Program Files\Steam\steamapps\common";
        private string steamgamesdir;
        private AutoProfilesViewModel autoProfVM;
        private AutoProfileHolder autoProfileHolder;
        private ProfileList profileList;
        private bool autoDebug;

        public AutoProfileHolder AutoProfileHolder { get => autoProfileHolder;
            set => autoProfileHolder = value; }
        public AutoProfilesViewModel AutoProfVM { get => autoProfVM; }
        public bool AutoDebug { get => autoDebug; }
        public event EventHandler AutoDebugChanged;

        public AutoProfiles()
        {
            InitializeComponent();

            if (!File.Exists(Global.appdatapath + @"\Auto Profiles.xml"))
                Global.CreateAutoProfiles(m_Profile);

            if (Global.UseCustomSteamFolder &&
                Directory.Exists(Global.CustomSteamFolder))
                steamgamesdir = Global.CustomSteamFolder;
            else if (Directory.Exists(steamCommx86Loc))
                steamgamesdir = steamCommx86Loc;
            else if (Directory.Exists(steamCommLoc))
                steamgamesdir = steamCommLoc;
            else
                addProgramsBtn.ContextMenu.Items.Remove(steamMenuItem);

            autoProfileHolder = new AutoProfileHolder();
        }

        public void SetupDataContext(ProfileList profileList)
        {
            autoProfVM = new AutoProfilesViewModel(autoProfileHolder, profileList);
            programListLV.DataContext = autoProfVM;
            programListLV.ItemsSource = autoProfVM.ProgramColl;
            
            revertDefaultProfileOnUnknownCk.DataContext = autoProfVM;

            autoProfVM.SearchFinished += AutoProfVM_SearchFinished;
            autoProfVM.CurrentItemChange += AutoProfVM_CurrentItemChange;

            this.profileList = profileList;

            foreach (UIElement element in Grid.Children)
            {
                if (element is ComboBox)
                {
                    ComboBox cb = (ComboBox)element;
                    CollectionContainer cc = cb.ItemsSource.OfType<CollectionContainer>().First();
                    cc.Collection = profileList.ProfileListCol;
                }
            }
        }

        private void AutoProfVM_CurrentItemChange(AutoProfilesViewModel sender, ProgramItem item)
        {
            if (item != null)
            {
                if (item.MatchedAutoProfile != null)
                {
                    for (int i = 0; i < Global.DS4_CONTROLLER_COUNT; ++i)
                    {
                        string profileName = item.MatchedAutoProfile.ProfileNames[i];
                        if (!string.IsNullOrEmpty(profileName) && profileName != "(none)")
                        {
                            ProfileEntity tempProf = profileList.ProfileListCol.SingleOrDefault(x => x.Name == profileName);
                            if (tempProf != null)
                            {
                                item.SelectedIndexCon[i] = profileList.ProfileListCol.IndexOf(tempProf) + 1;
                            }
                        }
                        else
                        {
                            item.SelectedIndexCon[i] = 0;
                        }
                    }
                }

                editControlsPanel.DataContext = item;
                editControlsPanel.IsEnabled = true;
            }
            else
            {
                editControlsPanel.DataContext = null;
                editControlsPanel.IsEnabled = false;

                foreach (UIElement element in Grid.Children)
                {
                    if (element is ComboBox)
                    {
                        ComboBox cb = (ComboBox)element;
                        cb.SelectedIndex = 0;
                    }
                }
            }
        }

        private void AutoProfVM_SearchFinished(object sender, EventArgs e)
        {
            IsEnabled = true;
        }

        private void SteamMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            steamMenuItem.Visibility = Visibility.Collapsed;
            programListLV.ItemsSource = null;
            autoProfVM.SearchFinished += AppsSearchFinished;
            autoProfVM.AddProgramsFromSteam(steamgamesdir);
        }

        private void BrowseProgsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                //browseProgsMenuItem.Visibility = Visibility.Collapsed;
                programListLV.ItemsSource = null;
                autoProfVM.SearchFinished += AppsSearchFinished;
                autoProfVM.AddProgramsFromDir(dialog.SelectedPath);
            }
            else
            {
                this.IsEnabled = true;
            }
        }

        private void StartMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            startMenuItem.Visibility = Visibility.Collapsed;
            programListLV.ItemsSource = null;
            autoProfVM.SearchFinished += AppsSearchFinished;
            autoProfVM.AddProgramsFromStartMenu();
        }

        private void AppsSearchFinished(object sender, EventArgs e)
        {
            autoProfVM.SearchFinished -= AppsSearchFinished;
            programListLV.ItemsSource = autoProfVM.ProgramColl;
        }

        private void AddProgramsBtn_Click(object sender, RoutedEventArgs e)
        {
            addProgramsBtn.ContextMenu.IsOpen = true;
            e.Handled = true;
        }

        private void HideUncheckedBtn_Click(object sender, RoutedEventArgs e)
        {
            programListLV.ItemsSource = null;
            autoProfVM.RemoveUnchecked();
            steamMenuItem.Visibility = Visibility.Visible;
            startMenuItem.Visibility = Visibility.Visible;
            browseProgsMenuItem.Visibility = Visibility.Visible;
            programListLV.ItemsSource = autoProfVM.ProgramColl;
        }

        private void ShowAutoDebugCk_Click(object sender, RoutedEventArgs e)
        {
            bool state = showAutoDebugCk.IsChecked == true;
            autoDebug = state;
            AutoDebugChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RemoveAutoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (autoProfVM.SelectedItem != null)
            {
                editControlsPanel.DataContext = null;
                autoProfVM.RemoveAutoProfileEntry(autoProfVM.SelectedItem);
                autoProfVM.AutoProfileHolder.Save(Global.appdatapath + @"\Auto Profiles.xml");
                autoProfVM.SelectedItem = null;
            }
        }

        private void SaveAutoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (autoProfVM.SelectedItem != null)
            {
                if (autoProfVM.SelectedItem.MatchedAutoProfile == null)
                {
                    autoProfVM.CreateAutoProfileEntry(autoProfVM.SelectedItem);
                }
                else
                {
                    autoProfVM.PersistAutoProfileEntry(autoProfVM.SelectedItem);
                }

                autoProfVM.AutoProfileHolder.Save(Global.appdatapath + @"\Auto Profiles.xml");
            }
        }

        private void BrowseAddProgMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.AddExtension = true;
            dialog.DefaultExt = ".exe";
            dialog.Filter = "Program (*.exe)|*.exe";
            dialog.Title = "Select Program";

            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (dialog.ShowDialog() == true)
            {
                programListLV.ItemsSource = null;
                autoProfVM.SearchFinished += AppsSearchFinished;
                autoProfVM.AddProgramExeLocation(dialog.FileName);
            }
            else
            {
                this.IsEnabled = true;
            }
        }

        private void MoveUpDownAutoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (autoProfVM.SelectedItem != null && sender != null)
            {
                if(autoProfVM.MoveItemUpDown(autoProfVM.SelectedItem, ((sender as MenuItem).Name == "MoveUp") ? -1 : 1))
                    autoProfVM.AutoProfileHolder.Save(Global.appdatapath + @"\Auto Profiles.xml");
            }
        }
    }
}
