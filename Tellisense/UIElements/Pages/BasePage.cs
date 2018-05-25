using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tellisense.Core;

namespace Tellisense
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {


        #region Animation

        public float SlideTime { get; set; } = 0.5f;
        public PageAnimation PageLoadAnim { get; set; } = PageAnimation.fadeIn;
        public PageAnimation PageUnLoadAnim { get; set; } = PageAnimation.fadeOut;

        public async Task AnimateIn()
        {
            if (PageLoadAnim == PageAnimation.None)
                return;

            switch (PageLoadAnim)
            {
                case PageAnimation.SlideAndFadeInRight:
                    await this.SlideAndFadeInRight(SlideTime);

                    break;

                case PageAnimation.fadeIn:
                    await this.FadeIn(SlideTime);

                    break;
            }
        }
        public async Task AnimateOut()
        {
            if (this.PageUnLoadAnim == PageAnimation.None)
                return;

            switch (PageUnLoadAnim)
            {
                case PageAnimation.SlideAndFadeOutLeft:
                    await this.SlideAndFadeOutleft(SlideTime / 3);

                    break;

                case PageAnimation.fadeOut:
                    await this.FadeOut(SlideTime);

                    break;
            }
        }

        #endregion

        #region Initialization

        private async void BasePage_loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        private async void BasePage_Unloaded(object sender, RoutedEventArgs e)
        {
            await AnimateOut();
        }
        public BasePage()
        {
            /*if (this.PageLoadAnim != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_loaded;*/
            ViewModel = new VM();
        }

        #endregion

        #region ViewModel

        private VM AViewModel;
        public VM ViewModel
        {
            get
            {
                return AViewModel;
            }

            set
            {
                if (AViewModel == value)
                    return;
                AViewModel = value;
                DataContext = AViewModel;
            }
        }

        #endregion

    }
}
