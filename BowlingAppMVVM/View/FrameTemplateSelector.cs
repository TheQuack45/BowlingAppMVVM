using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BowlingAppMVVM.ViewModel;

namespace BowlingAppMVVM.View
{
    public sealed class FrameTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                if (item is BowlerFrameViewModel)
                {
                    return element.FindResource("BowlerFrameTemplate") as DataTemplate;
                }
                else if (item is OneShotBowlerFrameViewModel)
                {
                    return element.FindResource("FinalBowlerFrameTemplate") as DataTemplate;
                }
            }

            return null;
        }
    }
}
