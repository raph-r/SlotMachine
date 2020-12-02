# Slot Machine
A Slot Machine game.
If you have any question, please, let me know.

## Engine
* Unity

## Features
* Weighted probability - number 7 -> 3 times

n_1 | n_2 | n_3 | result   | probability
 x  |  x  |  x  | bet * 50 | 1/1 * 1/10 * 1/10 
 7  |  ?  |  7  | bet / 2  | 1/10 * 1/1 * 1/10 
 x  |  x  |  $  | draw     | 1/1 * 1/10 * 1/1  
 x  |  $  |  x  | bet * 2  | 1/1 * 1/1 * 1/10
 
 x = 0~9 \n
 ? = number != 7 \n
 $ = number != x

## Controls
* LMB - Action

## Author
* **Raphael Rodrigues Teixeira de Freitas** - [GitHub](https://github.com/raph-r) - [LinkedIn](https://www.linkedin.com/in/raphael-rodrigues-teixeira-de-freitas/)

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
