using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using DynamicData;
using NoteGenerator.Models;
using NoteGenerator.Tools;
using ReactiveUI;

namespace NoteGenerator.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private NoteSelection _noteSelection;
    private ObservableCollection<string> _fullNotes;    
    private ObservableCollection<string> _halfNotes;
    private ObservableCollection<string> _allNotes;
    private int _repeats;
    private string _resultNotes;

    private bool _fullNoteSelection;
    private bool _halfNoteSelection;
    private bool _allNoteSelection;



    public bool AllNoteSelection
    {
        get => _allNoteSelection;
        set
        {
            this.RaiseAndSetIfChanged(ref _allNoteSelection, value);
            this._noteSelection = NoteSelection.AllNotes;
        }
    }

    public bool HalfNoteSelection
    {
        get => _halfNoteSelection;
        set
        {
            this.RaiseAndSetIfChanged(ref _halfNoteSelection, value);
            this._noteSelection = NoteSelection.HalfNotes;
        }
    }

    public bool FullNoteSelection
    {
        get => _fullNoteSelection;
        set
        {
            this.RaiseAndSetIfChanged(ref _fullNoteSelection, value);
            this._noteSelection = NoteSelection.FullNotes;
        }
    }

    public string ResultNotes
    {
        get => _resultNotes;
        set => this.RaiseAndSetIfChanged(ref _resultNotes, value);
    }
    
    public int Repeats
    {
        get => _repeats;
        set => this.RaiseAndSetIfChanged(ref _repeats, value);
    }

    public ObservableCollection<string> AllNotes
    {
        get => _allNotes;
        set => this.RaiseAndSetIfChanged(ref _allNotes, value);
    }
    
    public ObservableCollection<string> HalfNotes
    {
        get => _halfNotes;
        set => this.RaiseAndSetIfChanged(ref _halfNotes, value);
    }    

    public ObservableCollection<string> FullNotes
    {
        get => _fullNotes;
        set => this.RaiseAndSetIfChanged(ref _fullNotes, value);
    }
    
    
    
    public ICommand GenerateCommand { get; set; }

    
    
    public MainWindowViewModel()
    {
        _noteSelection = NoteSelection.FullNotes;
        FullNoteSelection = true;
        Repeats = 1;
        
        FullNotes = new ObservableCollection<string>() { "A", "B", "C", "D", "E", "F", "G" };
        HalfNotes = new ObservableCollection<string>() { "A#", "C#", "D#", "F#", "G#"  };
        AllNotes = new ObservableCollection<string>();        
        AllNotes.AddRange(FullNotes);
        AllNotes.AddRange(HalfNotes);
        GenerateCommand = ReactiveCommand.Create(Generate);
    }

    private void Generate()
    {
        this.ResultNotes = string.Empty;

        switch(_noteSelection)
        {
            case NoteSelection.FullNotes:
                DisplayNotes(FullNotes);
                break;
            
            case NoteSelection.HalfNotes:
                DisplayNotes(HalfNotes);
                break;
            
            case NoteSelection.AllNotes:
                DisplayNotes(AllNotes);
                break;
        }
    }

    private void DisplayNotes(ObservableCollection<string> notes)
    {
        StringBuilder builder = new StringBuilder();
        for(int i = 0; i < Repeats; i++)
        {
            notes.Shuffle();
            foreach(var s in notes)
                builder.Append($"{s}\t\t");
            builder.AppendLine();
        }
        this.ResultNotes = builder.ToString();
    }
}