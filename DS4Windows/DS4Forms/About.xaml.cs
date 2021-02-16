using System.Diagnostics;
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
            Process.Start(new ProcessStartInfo("https://docs.google.com/document/d/1CovpH08fbPSXrC6TmEprzgPwCe0tTjQ_HTFfDotpmxk/edit?usp=sharing") { UseShellExecute = true });
        }

        private void PaypalLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://paypal.me/ryochan7") { UseShellExecute = true });
        }

        private void PatreonLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://patreon.com/user?u=501036") { UseShellExecute = true });
        }

        private void SubscribeStartLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://subscribestar.com/ryochan7") { UseShellExecute = true });
        }

        private void SiteLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://ryochan7.github.io/ds4windows-site/") { UseShellExecute = true });
        }

        private void SourceLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Ryochan7/DS4Windows") { UseShellExecute = true });
        }

        private void Jays2KingsLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Jays2Kings/") { UseShellExecute = true });
        }

        private void InhexSTERLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://code.google.com/p/ds4-tool/") { UseShellExecute = true });
        }

        private void ElectrobrainsLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://code.google.com/r/brianfundakowskifeldman-ds4windows/") { UseShellExecute = true });
        }

        private void YoutubeSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/channel/UCIoUA_XLlCSZbvZGeg3Byeg") { UseShellExecute = true });
        }

        private void BitchuteSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.bitchute.com/channel/uE2CbiV96u1k/") { UseShellExecute = true });
        }

        private void BittubeSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://bittube.tv/profile/ds4windows") { UseShellExecute = true });
        }

        private void TwitterSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://twitter.com/ds4windows") { UseShellExecute = true });
        }

        private void MastodonSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://fosstodon.org/@ds4windows") { UseShellExecute = true });
        }

        private void MindsSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.minds.com/ds4windows/") { UseShellExecute = true });
        }

        private void DiscordSocialBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://discord.gg/zrpPgyN") { UseShellExecute = true });
        }
    }
}
