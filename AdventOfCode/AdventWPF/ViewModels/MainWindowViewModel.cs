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
    private readonly Day7 _day7;
    //private readonly Day8 _day8;
    //private readonly Day9 _day9;
    //private readonly Day10 _day10;
    //private readonly Day11 _day11;
    //private readonly Day12 _day12;
    //private readonly Day13 _day13;
    //private readonly Day14 _day14;
    //private readonly Day15 _day15;
    //private readonly Day16 _day16;
    //private readonly Day17 _day17;
    //private readonly Day18 _day18;
    //private readonly Day19 _day19;
    //private readonly Day20 _day20;
    //private readonly Day21 _day21;
    //private readonly Day22 _day22;
    //private readonly Day23 _day23;
    //private readonly Day24 _day24;
    //private readonly Day25 _day25;
    
    
    public ObservableCollection<string> Items { get; set; }

    public MainWindowViewModel()
    {
        _day1 = new Day1();
        _day2 = new Day2();
        _day3 = new Day3();
        _day4 = new Day4();
        _day5 = new Day5();
        _day6 = new Day6();
        _day7 = new Day7();
        //_day8 = new Day8();
        //_day9 = new Day9();
        //_day10 = new Day10();
        //_day11 = new Day11();
        //_day12 = new Day12();
        
        Day1Command = new DelegateCommand(UpdateDay1);
        Day2Command = new DelegateCommand(UpdateDay2);
        Day3Command = new DelegateCommand(UpdateDay3);
        Day4Command = new DelegateCommand(UpdateDay4);
        Day5Command = new DelegateCommand(UpdateDay5);
        Day6Command = new DelegateCommand(UpdateDay6);
        //Day7Command = new DelegateCommand(UpdateDay7);
        
    }
    
    public DelegateCommand Day1Command { get; set; }
    public DelegateCommand Day2Command { get; set; }
    public DelegateCommand Day3Command { get; set; }
    public DelegateCommand Day4Command { get; set; }
    public DelegateCommand Day5Command { get; set; }
    public DelegateCommand Day6Command { get; set; }
    public DelegateCommand Day7Command { get; set; }


    private void UpdateDay1() { UpdateDay(Day1.SolvePuzzle());} 
    private void UpdateDay2() { UpdateDay(Day2.SolvePuzzle());}
    private void UpdateDay3() { UpdateDay(Day3.SolvePuzzle());}
    private void UpdateDay4() { UpdateDay(Day4.SolvePuzzle());}
    private void UpdateDay5() { UpdateDay(Day5.SolvePuzzle());}
    private void UpdateDay6() { UpdateDay(Day6.Lights());}
    //private void UpdateDay7() { UpdateDay(Day7);}

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