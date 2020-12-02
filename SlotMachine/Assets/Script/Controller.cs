using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Referencias para UI


public class WeightedNumber
{
    private Dictionary<int, int> weighted_numbers;
    private System.Random random;
    private int total_weight;

    public WeightedNumber()
    {
        this.weighted_numbers = new Dictionary<int, int>();
        this.random = new System.Random();
        this.total_weight = 0;
    }

    public void add_weighted_number(int number, int weight)
    {
        this.weighted_numbers.Add(number, weight);
        this.total_weight += weight;
    }

    // Sorteia um número dentre os adicionados em weighted_numbers
    // use_weight == true -> considera o peso dos numeros
    // use_weight == false -> nao considera o peso dos numeros
    public int draw_number(bool use_weight = true)
    {
        double x = this.random.NextDouble() * ((use_weight) ? this.total_weight : this.weighted_numbers.Count);
        foreach (var weighted_number in this.weighted_numbers)
        {
            x -= ((use_weight) ? weighted_number.Value : 1);
            if (x < 0)
            {
                return weighted_number.Key;
            }
        }
        return 0;
    }
}

public class Controller : MonoBehaviour
{
    // Número que terá o maior peso
    private int greater_weighted_number = 7;

    public Text text_number_1;
    public Text text_number_2;
    public Text text_number_3;
    private int number_1 = 0;
    private int number_2 = 0;
    private int number_3 = 0;

    public Text text_wallet;
    private int wallet = 1000;
    
    public InputField input_field_bet;

    private WeightedNumber weighted_number;

    public void play()
    {
        this.start_weighted_numbers();
        if(this.input_field_bet.text != "")
        {
            int bet = int.Parse(input_field_bet.text);
            // Verifica se o jogador pode fazer esta aposta 
            if ((this.wallet - bet) >= 0)
            {
                this.draw();
                this.update_text_field();
                this.calculate_resut(bet);
            }
        }
    }

    // Cria os números a serem sorteados e os seus pesos
    private void start_weighted_numbers()
    {
        if (this.weighted_number == null)
        {
            this.weighted_number = new WeightedNumber();
            for (int i = 0; i < 10; i++)
            {
                this.weighted_number.add_weighted_number(i, (i == this.greater_weighted_number ? 3 : 1));
            }
        }
    }

    private void calculate_resut(int bet)
    {
        this.update_wallet(bet * -1);
        if (this.is_jackpot())
        {
            this.update_wallet(bet * 50);
        }
        else if (this.is_half_deal())
        {
            this.update_wallet(bet / 2);
        }
        else if (this.is_first_and_second_equals())
        {
            this.update_wallet(bet);
        }
        else if (this.is_first_and_third_equals())
        {
            this.update_wallet(bet * 2);
        }
    }

    private bool is_jackpot()
    {
        return this.number_1 == this.number_2 && this.number_1 == this.number_3;
    }

    private bool is_half_deal()
    {
        return this.number_1 == this.greater_weighted_number && this.number_3 == this.greater_weighted_number;
    }

    private bool is_first_and_second_equals()
    {
        return this.number_1 == this.number_2;
    }

    private bool is_first_and_third_equals()
    {
        return this.number_1 == this.number_3;
    }

    private void draw()
    {
        this.number_1 = this.weighted_number.draw_number();
        this.number_2 = this.weighted_number.draw_number(false); // Diminui as chances do jackpot por causa do número "viciado"
        this.number_3 = this.weighted_number.draw_number(); 
    }

    private void update_text_field()
    {
        this.text_number_1.text = this.number_1.ToString();
        this.text_number_2.text = this.number_2.ToString();
        this.text_number_3.text = this.number_3.ToString();
    }

    private void update_wallet(int value)
    {
        this.wallet += value;
        this.text_wallet.text = this.wallet.ToString("R$ 0.00");
    }
}
