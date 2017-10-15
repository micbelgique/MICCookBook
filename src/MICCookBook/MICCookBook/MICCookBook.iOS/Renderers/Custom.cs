using CoreGraphics;
using MICCookBook.Controls;
using MICCookBook.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace MICCookBook.iOS.Renderers
{
    public class CustomFrameRenderer : FrameRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);
            var elem = (MICCookBook.Controls.CustomFrame)this.Element;
            if (elem != null)
            {

                Layer.CornerRadius = 5;
                if (Element.BackgroundColor == Xamarin.Forms.Color.Default)
                {
                    Layer.BackgroundColor = UIColor.White.CGColor;
                }
                else
                {
                    Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();
                }

                Layer.ShadowRadius = 5;
                Layer.ShadowColor = UIColor.DarkGray.CGColor;
                Layer.ShadowOpacity = 0.2f;
                Layer.ShadowOffset = new CGSize(1, 1);

                if (Element.OutlineColor == Xamarin.Forms.Color.Default)
                {
                    Layer.BorderColor = UIColor.Clear.CGColor;
                }
                else
                {
                    Layer.BorderColor = Element.OutlineColor.ToCGColor();
                    Layer.BorderWidth = 1;
                }

                Layer.RasterizationScale = UIScreen.MainScreen.Scale;
                Layer.ShouldRasterize = true;

            }
        }
    }
}
