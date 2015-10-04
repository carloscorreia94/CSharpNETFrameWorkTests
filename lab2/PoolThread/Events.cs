using System;
// este delegate e' a base para o event Move do slider
delegate bool MoveEventHandler(object source, MoveEventArgs e);

// esta  classe contem os argumentos do evento move do slider
public class MoveEventArgs : EventArgs
{
    public int FinalMove { get; 
        internal set; }
    //private int FinalMove

    public MoveEventArgs(int FinalMove)
    {
        this.FinalMove = FinalMove;
    }
}


class Slider
{
    private int position;
    public event MoveEventHandler sliderMoved;

    public bool OnSliderMove(int newPosition)
    {
        // If there exist any subscribers call the event
        if (sliderMoved != null)
        {
            return sliderMoved(this, new MoveEventArgs(newPosition));
        }

        return true;
    }

    public int Position
    {
        get
        {
            return position;
        }
        // e' este bloco que e' executado quando se move o slider
        set
        {
            if (OnSliderMove(value))
                this.position = value;
        }
    }
}


class Form
{
    static void Main()
    {
        Slider slider = new Slider();
        slider.sliderMoved += new MoveEventHandler(slider_Move);
        // TODO: register with the Move event
        // estas sao as duas alteracoes simuladas no slider
        slider.Position = 20;
        Console.WriteLine("Position = " + slider.Position);
        slider.Position = 60;
        Console.WriteLine("Position = " + slider.Position);

        Console.Read();
    }

    // este é o método que deve ser chamado quando o slider e' movido
    static bool slider_Move(object source, MoveEventArgs e)
    {
        if (e.FinalMove > 50)
        {
            Console.WriteLine("too much.");
            return false;
        }
        else
            return true;
    }
}