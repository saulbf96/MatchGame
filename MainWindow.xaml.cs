using System.Text;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//agregamos esto para el temporalizador 
using System.Windows.Threading;

namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //agregamos el timer 
    DispatcherTimer timer = new DispatcherTimer();
    int tenthsOfSecondsElapsed;
    int matchesFound;
    public MainWindow()
    {
        InitializeComponent();
        timer.Interval = TimeSpan.FromSeconds(.1);
        timer.Tick += Timer_Tick;
        SetUpGame();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        tenthsOfSecondsElapsed++;
        timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
        if(matchesFound == 8)
        {
            timer.Stop();
            timeTextBlock.Text = timeTextBlock.Text + "- play again?";
        }
    }

    //variables
    //declaramos variables de tipo textbloclok
    TextBlock lastTexBlockClicked;
    //agregamos una variable de tipo bool donde se encargara si se le dara click o no 
    bool findingMatch = false;



    private void SetUpGame()
    {
        /* este metodo toma 8 pares de emojis de animales y los asiganara aleatoriamente, a los controles
         * text block  para que el jugador pueda emparejarlos
         * datos de entrada una lista de emojis 
         * 
        */
        //inicialisamos la lista y ponemos emojis que seran pares para  el match
        //estoo actualizara el text box con estos emojis 
        List<string> animalEmoji = new List<string>()
        {
            "🦝","🦝",
            "🐶","🐶",
            "🐄","🐄",
            "🦊","🦊",
            "🐱","🐱",
            "🦒","🦒",
            "🦨","🦨",
            "🐷","🐷"
        };



        //ahora usamos el metodo Random  hacemos ina instancia a ese metodo
        Random  random = new Random();

        //con un foreach recorremos todos los emojis 
        // este se encarga de asignar emojis aleatoriamente  a los textblock 
        //mainGrid es  el padre sus hijos son los que estan adentros 
        foreach (TextBlock  textBlock in mainGrid.Children.OfType<TextBlock>())
        {
            if (textBlock.Name != "timeTextBlock")
            {
                textBlock.Visibility = Visibility.Visible;
                //declaramos una variable tipo int para el index  y contar los emojis 
                //genera un index aleatorio basado en los emojis 
                int index = random.Next(animalEmoji.Count);
                //declaramos una variable string indexiar los emojis ya que son string la lista 
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

        }
        //aqui removemos el juego  y se finaliza el juego 
        timer.Start();
        tenthsOfSecondsElapsed = 0;
        matchesFound = 0;


    }

   

    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        //metodo del boton al clicked
        //declaracion de variable para enviar el click 
        TextBlock textBlock = sender as TextBlock;
        
        //si findingmatch es false habilitamos para el clik 
        if (findingMatch == false )
        {
            //esto significa  este elemento desaparece pero esta ocupando ese espacio 
            textBlock.Visibility = Visibility.Hidden;
            lastTexBlockClicked = textBlock;
            findingMatch = true;

        }
        else if (textBlock.Text == lastTexBlockClicked.Text)

        {
            matchesFound++;
            textBlock.Visibility = Visibility.Hidden;
            findingMatch = false;


        }
        else
        {
            lastTexBlockClicked.Visibility = Visibility.Visible;
            findingMatch = false;
        }



    }

    private void TimeTexBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (matchesFound == 8)
        {
            SetUpGame();
        }
       /* else
        {
            MessageBox.Show("reiniciar juego si o no ");
            string res;
            res = Console.ReadLine();
            if (res =="si")
            {
                SetUpGame();
            }
            else
            {
                MessageBox.Show("game over ");
            }
        }*/
    }
}