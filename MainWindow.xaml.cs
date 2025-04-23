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

namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SetUpGame();
    }
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
            //declaramos una variable tipo int para el index  y contar los emojis 
            //genera un index aleatorio basado en los emojis 
            int index = random.Next(animalEmoji.Count);
            //declaramos una variable string indexiar los emojis ya que son string la lista 
            string nextEmoji = animalEmoji[index];
            textBlock.Text = nextEmoji;
            animalEmoji.RemoveAt(index);

        }


    }
}