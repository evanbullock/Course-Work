/////////////////////////////////////////////////////////////
//**Programmer:Evan Bullock, Gal Zahavi
//**Date:4/24/2018
//**Section:CPTS 122 section 06
//**Desc: Programming Assignment 9:  Graphical Application
//** using SFML LIBRARIES
//**
/////////////////////////////////////////////////////////////

#include "Header.h"
#include <SFML\Graphics.hpp>
#include <SFML\Window.hpp>
//BACKGROUND/SOME IMPLEMENTATION FOUND FROM https://www.youtube.com/watch?v=4Vg9d1pjL20
menu::menu(float width, float height)
{
	if (!font.loadFromFile("OpenSans-Bold.ttf"))
	{


	}
	text[3].setFont(font);
	text[3].setColor(Color::Green);
	text[3].setString("Escape 32! ");
	text[3].setPosition(Vector2f(200, 15));
	text[3].setScale(1.6,1.6);
	

	text[0].setFont(font);
	text[0].setColor(Color::Green);
	text[0].setString("1.) Play");
	text[0].setPosition(Vector2f(220,200));

	text[1].setFont(font);
	text[1].setColor(Color::Green);
	text[1].setString("2.) How to play");
	text[1].setPosition(Vector2f(220, 300));
	
	text[2].setFont(font);
	text[2].setColor(Color::Green);
	text[2].setString("3.) Exit");
	text[2].setPosition(Vector2f(220, 400));
		
	
}

menu::~menu()
{
}

void menu::draw(RenderWindow & window)
{
	for (int i = 0;i < 4; i++)
	{
		window.draw(text[i]);
}
}

void menu::setback(RenderWindow & window)
{
	sf::RectangleShape shape1(sf::Vector2f(600, 600));
	sf::Texture *Bkg;
	Bkg = new sf::Texture();
	if (!Bkg->loadFromFile("menuback.png"))
	{
		return;
	}
	shape1.setTexture(Bkg);
	window.draw(shape1);
}

winScreen::winScreen(float width, float height,bool won,int movements)
{
	if (!font.loadFromFile("OpenSans-Bold.ttf"))
	{


	}	text[0].setColor(Color::Green);

	text[1].setFont(font);
	text[1].setColor(Color::Green);
	if(won==true)
	{ 
	text[1].setString("You Won!");
	}
	if (won == false)
	{
		text[1].setColor(Color::Red);
		text[1].setString("You Lose!");
		text[0].setColor(Color::Red);


	}
	text[1].setPosition(Vector2f(200, 15));
	text[1].setScale(1.6, 1.6);

	string move;
	
	move=to_string(movements);
	text[0].setFont(font);
	text[0].setString("Total Movements: "+move);
	text[0].setPosition(Vector2f(160, 200));
	
	
}

winScreen::~winScreen()
{
}

void winScreen::draw(RenderWindow & window)
{
	for (int i = 0;i < 2; i++)
	{
		window.draw(text[i]);
	}
}

void winScreen::setback(RenderWindow & window)
{
	sf::RectangleShape shape1(sf::Vector2f(600, 600));
	sf::Texture *Bkg;
	Bkg = new sf::Texture();
	if (!Bkg->loadFromFile("menuback.png"))
	{
		return;
	}
	shape1.setTexture(Bkg);
	window.draw(shape1);
}
