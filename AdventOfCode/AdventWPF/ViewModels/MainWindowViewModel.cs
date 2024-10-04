using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Advent2015.Days;

namespace AdventWPF.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly Day1 _day1;
    private readonly Day2 _day2;
    private readonly Day3 _day3;
    private readonly Day4 _day4;
    private readonly Day5 _day5;
    private readonly Day6 _day6;
    
    
    public ObservableCollection<string> Items { get; set; }

    public MainWindowViewModel()
    {
        _day1 = new Day1();
        _day2 = new Day2();
        _day3 = new Day3();
        _day4 = new Day4();
        _day5 = new Day5();
        _day6 = new Day6();
        Day1Command = new DelegateCommand(UpdateDay1);
        Day2Command = new DelegateCommand(UpdateDay2);
        Day3Command = new DelegateCommand(UpdateDay3);
        Day4Command = new DelegateCommand(UpdateDay4);
        Day5Command = new DelegateCommand(UpdateDay5);
        Day6Command = new DelegateCommand(UpdateDay6);
        
    }
    
    public DelegateCommand Day1Command { get; set; }
    public ICommand Day2Command { get; set; }
    public ICommand Day3Command { get; set; }
    public ICommand Day4Command { get; set; }
    public ICommand Day5Command { get; set; }
    public ICommand Day6Command { get; set; }


    private void UpdateDay1() { UpdateDay(Day1.GetFloor());} 
    private void UpdateDay2() { UpdateDay(Day2.CalculateAmountOfPaper());}
    private void UpdateDay3() { UpdateDay(Day3.CountHouses());}
    private void UpdateDay4() { UpdateDay(Day4.MineCoin());}
    private void UpdateDay5() { UpdateDay(Day5.GetNiceStringAmount());}
    private void UpdateDay6() { UpdateDay(Day6.Lights());}

    private void UpdateDay(string[] input)
    {
        Items = new ObservableCollection<string>(input);
        OnPropertyChanged(nameof(Items));
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}