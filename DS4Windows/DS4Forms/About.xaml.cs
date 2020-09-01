using DS4Windows;
using System.Windows;

namespace DS4WinWPF.DS4Forms
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();

            string version = Global.exeversion;
            headerLb.Content += version + ")";
        }

        private void ChangeLogLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void PaypalLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void PatreonLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void SubscribeStartLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void SiteLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void SourceLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void Jays2KingsLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/Jays2Kings/");
        }

        private void InhexSTERLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://code.google.com/p/ds4-tool/");
        }

        private void ElectrobrainsLink_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://code.google.com/r/brianfundakowskifeldman-ds4windows/");
        }

        private void YoutubeSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void BitchuteSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void BittubeSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void TwitterSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void MastodonSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void MindsSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }

        private void DiscordSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://discord.gg/zrpPgyN");
        }

        private void ParlerSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Util.StartProcessHelper("https://github.com/grasmanek94/DS4Windows/");
        }
    }
}
