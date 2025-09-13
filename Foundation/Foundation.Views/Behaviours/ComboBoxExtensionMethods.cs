//-----------------------------------------------------------------------
// <copyright file="ComboBoxExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Foundation.Views.Behaviours
{
    /// <summary>
    /// Combo Box Extension methods
    /// </summary>
    public static class ComboBoxExtensionMethods
    {
        /// <summary>
        /// Sets the width of the dropdown based on the contents
        /// </summary>
        /// <param name="comboBox"></param>
        public static void SetWidthFromItems(this ComboBox comboBox)
        {
            Double comboBoxWidth = 19; // comboBox.DesiredSize.Width;

            // Create the peer and provider to expand the comboBox in code behind. 
            ComboBoxAutomationPeer peer = new ComboBoxAutomationPeer(comboBox);
            Object? o = peer.GetPattern(PatternInterface.ExpandCollapse);

            if (o is IExpandCollapseProvider provider)
            {
                void EventHandler(Object? sender, EventArgs e)
                {
                    if (comboBox.IsDropDownOpen &&
                        comboBox.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                    {
                        Double width = 0;
                        foreach (var item in comboBox.Items)
                        {
                            if (comboBox.ItemContainerGenerator.ContainerFromItem(item) is ComboBoxItem comboBoxItem)
                            {
                                comboBoxItem.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                                if (comboBoxItem.DesiredSize.Width > width)
                                {
                                    width = comboBoxItem.DesiredSize.Width;
                                }
                            }
                        }

                        comboBox.Width = comboBoxWidth + width;
                        // Remove the event handler. 
                        comboBox.ItemContainerGenerator.StatusChanged -= EventHandler;
                        comboBox.DropDownOpened -= EventHandler;
                        provider.Collapse();
                    }
                }

                comboBox.ItemContainerGenerator.StatusChanged += EventHandler;
                comboBox.DropDownOpened += EventHandler;
                // Expand the comboBox to generate all its ComboBoxItem's. 
                provider.Expand();
            }
        }
    }
}
