using System;
using Xamarin.Forms;

namespace Swiper
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.LayoutChanged += (object sender, EventArgs e) =>
            {
                this.SwipeCardView.CardMoveDistance = (int)(this.Width * 0.20f);
            };
        }

        //private void OnSwipeLeftClicked(object sender, EventArgs e)
        //{
        //    this.SwipeCardView.InvokeSwipeLeft(50, 20);
        //}

        //private void OnSwipeRightClicked(object sender, EventArgs e)
        //{
        //    this.SwipeCardView.InvokeSwipeRight(1000, 1);
        //}
    }
}
