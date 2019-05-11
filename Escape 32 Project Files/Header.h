/////////////////////////////////////////////////////////////
//**Programmer:Evan Bullock, Gal Zahavi
//**Date:4/24/2018
//**Section:CPTS 122 section 06
//**Desc: Programming Assignment 9:  Graphical Application
//** using SFML LIBRARIES
//**
/////////////////////////////////////////////////////////////
#pragma once

#include <SFML/Graphics.hpp>
#include <SFML/Audio.hpp>
#include <SFML/Window.hpp>
#include <string>
#include <iostream>

using namespace std; //we used this , sorry
using namespace sf; //we used this , sorry

class menu
{
public:	
menu(float width,float height);
~menu();
void draw(RenderWindow &window);
void setback(RenderWindow &window);
private:
Font font;
Text  text[4];
};
class winScreen
{
public:
	winScreen(float width, float height,bool won,int movements);
	~winScreen();
	void draw(RenderWindow &window);
	void setback(RenderWindow &window);
private:
	Font font;
	Text  text[2];
};
int setHow(sf::RenderWindow & wind);

bool drawlaser(sf::RenderWindow & wind, CircleShape &player);
void andiLaugh();
void doMenu();
int run();
void playerCollisions(CircleShape &rect, int type, int keyPress,bool &won);
void updatePlayer(CircleShape &rect, int keyPress,bool &won);
int setBackground(sf::RenderWindow & wind);