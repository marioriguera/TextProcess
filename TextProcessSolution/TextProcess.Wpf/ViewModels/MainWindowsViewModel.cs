using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TextProcess.Wpf.Commands;
using TextProcess.Wpf.Configuration;

namespace TextProcess.Wpf.ViewModels
{
    /// <summary>
    /// ViewModel for the main window of the application. Manages the user interface, properties, and commands.
    /// </summary>
    public class MainWindowsViewModel : INotifyPropertyChanged
    {
        #region Fields

        // Locks
        private readonly object _lockText = new object();

        // Fields for various properties
        private string _tittle;
        private string _closeButtonContent;
        private ulong _numberOfHyphen;
        private ulong _numberOfWords;
        private ulong _numberOfWhiteSpaces;
        private string _numberOfHyphenTittle;
        private string _numberOfWordsTittle;
        private string _numberOfWhiteSpacesTittle;
        private string _textToProcess;
        private string _insertTextTittle;
        private string _orderTittle;
        private List<ComboBoxItem> _orders;
        private ComboBoxItem _selectedOrder;
        private List<ListViewItem> _lines;

        // Services
        // private readonly IOrderOptionsService _orderOptionsService;
        // private readonly IOrderFactory _orderFactory;
        // private readonly ITextAnalyzer _textAnalyser;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowsViewModel"/> class.
        /// </summary>
        public MainWindowsViewModel()
        {
            Tittle = $"Process Text App";
            CloseButtonContent = $"Cerrar";
            InsertTextTittle = $"Insertar texto en el cuadro";
            NumberOfHyphenTittle = $"Cantidad de guiones";
            NumberOfWordsTittle = $"Cantidad de palabras";
            NumberOfWhiteSpacesTittle = $"Cantidad de espacios";
            OrderTittle = $"Orden";

            NumberOfHyphen = ulong.MinValue;
            NumberOfWords = ulong.MinValue;
            NumberOfWhiteSpaces = ulong.MinValue;

            Orders = new List<ComboBoxItem>();
            Lines = new List<ListViewItem>();

            // Initializes commands.
            CloseAppCommand = new RelayCommand<object>(CanExecuteCloseAppCommand, ExecuteCloseAppCommand);

            // Dependencies
            // if (!ConfigurationService.IsInDesignMode)
            // {
            //     _orderOptionsService = ConfigurationService.Current.Host.Services.GetRequiredService<IOrderOptionsService>();
            //     _orderFactory = ConfigurationService.Current.Host.Services.GetRequiredService<IOrderFactory>();
            //     _textAnalyser = ConfigurationService.Current.Host.Services.GetRequiredService<ITextAnalyzer>();
            //     UpdateOrders();
            // }
        }

        /// <summary>
        /// Subscribe for property changed events.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a text value of app tittle.
        /// </summary>
        public string Tittle
        {
            get => _tittle;
            set
            {
                if (_tittle != value)
                {
                    _tittle = value;
                    NotifyPropertyChanged(nameof(Tittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets a text to process.
        /// </summary>
        public string TextToProcess
        {
            get => _textToProcess;
            set
            {
                if (_textToProcess != value)
                {
                    _textToProcess = value;
                    DoProcessText();
                    NotifyPropertyChanged(nameof(TextToProcess));
                }
            }
        }

        /// <summary>
        /// Gets or sets a insert text tittle.
        /// </summary>
        public string InsertTextTittle
        {
            get => _insertTextTittle;
            set
            {
                if (_insertTextTittle != value)
                {
                    _insertTextTittle = value;
                    NotifyPropertyChanged(nameof(InsertTextTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets a text value of number of hyphen tittle.
        /// </summary>
        public string NumberOfHyphenTittle
        {
            get => _numberOfHyphenTittle;
            set
            {
                if (_numberOfHyphenTittle != value)
                {
                    _numberOfHyphenTittle = value;
                    NotifyPropertyChanged(nameof(NumberOfHyphenTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of words tittle.
        /// </summary>
        public string NumberOfWordsTittle
        {
            get => _numberOfWordsTittle;
            set
            {
                if (_numberOfWordsTittle != value)
                {
                    _numberOfWordsTittle = value;
                    NotifyPropertyChanged(nameof(NumberOfWordsTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of white spaces tittle.
        /// </summary>
        public string NumberOfWhiteSpacesTittle
        {
            get => _numberOfWhiteSpacesTittle;
            set
            {
                if (_numberOfWhiteSpacesTittle != value)
                {
                    _numberOfWhiteSpacesTittle = value;
                    NotifyPropertyChanged(nameof(NumberOfWhiteSpacesTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets order tittle.
        /// </summary>
        public string OrderTittle
        {
            get => _orderTittle;
            set
            {
                if (_orderTittle != value)
                {
                    _orderTittle = value;
                    NotifyPropertyChanged(nameof(OrderTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of hyphen type characters.
        /// </summary>
        public ulong NumberOfHyphen
        {
            get => _numberOfHyphen;
            set
            {
                if (_numberOfHyphen != value)
                {
                    _numberOfHyphen = value;
                    NotifyPropertyChanged(nameof(NumberOfHyphen));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of words.
        /// </summary>
        public ulong NumberOfWords
        {
            get => _numberOfWords;
            set
            {
                if (_numberOfWords != value)
                {
                    _numberOfWords = value;
                    NotifyPropertyChanged(nameof(NumberOfWords));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of white spaces.
        /// </summary>
        public ulong NumberOfWhiteSpaces
        {
            get => _numberOfWhiteSpaces;
            set
            {
                if (_numberOfWhiteSpaces != value)
                {
                    _numberOfWhiteSpaces = value;
                    NotifyPropertyChanged(nameof(NumberOfWhiteSpaces));
                }
            }
        }

        /// <summary>
        /// Gets or sets a text value of close button.
        /// </summary>
        public string CloseButtonContent
        {
            get => _closeButtonContent;
            set
            {
                if (_closeButtonContent != value)
                {
                    _closeButtonContent = value;
                    NotifyPropertyChanged(nameof(CloseButtonContent));
                }
            }
        }

        /// <summary>
        /// Gets or sets orders.
        /// </summary>
        public List<ComboBoxItem> Orders
        {
            get => _orders;
            set
            {
                if (_orders != value)
                {
                    _orders = value;
                    NotifyPropertyChanged(nameof(Orders));
                }
            }
        }

        /// <summary>
        /// Gets or sets lines.
        /// </summary>
        public List<ListViewItem> Lines
        {
            get => _lines;
            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    NotifyPropertyChanged(nameof(Lines));
                }
            }
        }

        /// <summary>
        /// Gets or sets selected order.
        /// </summary>
        public ComboBoxItem SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (_selectedOrder != value)
                {
                    _selectedOrder = value;
                    DoProcessText();
                    NotifyPropertyChanged(nameof(SelectedOrder));
                }
            }
        }

        /// <summary>
        /// Gets or sets close app command.
        /// </summary>
        public RelayCommand<object> CloseAppCommand { get; set; }

        /// <summary>
        /// Processes the text based on the selected order and updates the UI with the ordered lines.
        /// </summary>
        private void DoProcessText()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    if (SelectedOrder == null || TextToProcess == null) return;

                    IEnumerable<string> lines = null; // _orderFactory.GetOrderText(SelectedOrder.Name, TextToProcess);
                    UpdateLines(lines);
                    UpdateStatistics();
                }
                catch (Exception ex)
                {
                    ConfigurationService.Current.Logger.Error($"An unhandled exception has occurred processing the text: {TextToProcess} with order {SelectedOrder.Name}. Message: {ex.Message}.");
                }
            });
        }

        /// <summary>
        /// Updates statistics based on the processed text and selected order.
        /// </summary>
        private void UpdateStatistics()
        {
            try
            {
                // var statistics = _textAnalyser.AnalyzeText(TextToProcess);
                // 
                // // Update statistics properties
                // NumberOfHyphen = statistics.HyphenCount;
                // NumberOfWords = statistics.WordCount;
                // NumberOfWhiteSpaces = statistics.SpaceCount;
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Error($"An unhandled exception has occurred processing the text: {TextToProcess} with order {SelectedOrder.Name}. Message: {ex.Message}.");
            }
        }

        /// <summary>
        /// Updates the UI with the provided lines after processing.
        /// </summary>
        /// <param name="lines">The ordered lines to be displayed in the UI.</param>
        private void UpdateLines(IEnumerable<string> lines)
        {
            Lines.Clear();

            foreach (string line in lines)
            {
                Lines.Add(new ListViewItem()
                {
                    Content = line,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    FontSize = 25,
                });
            }

            NotifyPropertyChanged(nameof(Lines));
        }

        /// <summary>
        /// Updates the Orders collection based on the available order options.
        /// </summary>
        private void UpdateOrders()
        {
            try
            {
                // // Get the order options from the service
                // List<IOrderOption> orderOptions = _orderOptionsService.GetOrderOptions().ToList();
                // 
                // // Clear the existing Orders collection
                // Orders.Clear();
                // 
                // // Add new items to the collection
                // foreach (var option in orderOptions)
                // {
                //     AddComboBoxItem(option);
                // }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed (e.g., log or display an error message)
                ConfigurationService.Current.Logger.Error($"Error updating orders: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a ComboBoxItem to the Orders collection based on the provided order option.
        /// </summary>
        /// <param name="orderOption">The order option to add to the collection.</param>
        // private void AddComboBoxItem(IOrderOption orderOption)
        // {
        //     // Add a new ComboBoxItem to the Orders collection
        //     Orders.Add(new ComboBoxItem()
        //     {
        //         Content = orderOption.Description,
        //         Name = orderOption.Name,
        //         HorizontalAlignment = HorizontalAlignment.Stretch,
        //         VerticalAlignment = VerticalAlignment.Center,
        //         HorizontalContentAlignment = HorizontalAlignment.Stretch,
        //         VerticalContentAlignment = VerticalAlignment.Center,
        //         FontSize = 30,
        //     });
        // }

        /// <summary>
        /// Called by Set accessor of each property that needs to notify it's value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property it's value changed.</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Determines whether the Close App command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        /// <returns>True if the command can be executed; otherwise, false.</returns>
        private bool CanExecuteCloseAppCommand(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the Close App command, shutting down the application.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        private void ExecuteCloseAppCommand(object parameter)
        {
            try
            {
                // Shuts down the application.
                ConfigurationService.Current.Logger.Fatal($"Execute close application.");
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                // Logs any unhandled exceptions.
                ConfigurationService.Current.Logger.Error($"An unhandled exception has occurred in {nameof(ExecuteCloseAppCommand)} and the message is: {ex.Message}");
            }
        }
    }
}