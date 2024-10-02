/*
 * Name: Ciaran McIlvaney
 * Date: September 27th 2024
 */

// Include code libraries you need below (use the namespace).
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{

    public class Game
    {
        // Setting up colors for 2D drawing 
        Color skyColorBlue = new Color(0x00, 0x2b, 0x59);
        Color starColorCyan = new Color(0x00, 0xb9, 0xbe);
        Color moonColor = new Color(0x9f, 0xf4, 0xe5);
        Color moonCrevices = new Color(0x38, 0x6b, 0x6a);
        Color groundColor = new Color(0x42, 0xf5, 0xa7);

        // Stars 
        int[] xCoordinates = [40, 270, 100, 100, 300, 310, 170, 220, 80, 360, 360, 50, 210, 270, 30, 380];
        int[] yCoordinates = [40, 210, 350, 180, 320, 100, 250, 140, 110, 30, 250, 270, 330, 90, 170, 150];
        int starRadius = 10;
        bool[] starVisibility;

        // Varibles for random star placement
        int[] xCoordinatesForRandom = [];
        int[] yCoordinatesForRandom = [];

        // How many clicks on the stars the user entered 
        int clickCount = 0;


        public void Setup()
        {
            // Setting up window size and name
            Window.SetSize(400, 400);
            Window.SetTitle("Starry Night");

            // Set the visibility for each star to be true at the start
            starVisibility = new bool[xCoordinates.Length];
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                starVisibility[i] = true;
            }

            // Display stars randomly on the screen NightTimeLandscape
            int randomStarCount = 25;
            xCoordinatesForRandom = new int[randomStarCount];
            yCoordinatesForRandom = new int[randomStarCount];
            for (int i = 0; i < randomStarCount; i++)
            {
                xCoordinatesForRandom[i] = Random.Integer(10, 390);
                yCoordinatesForRandom[i] = Random.Integer(10, 325);
            }

        }
        public void Update()
        {
            // Sets background to Sky Blue 
            Window.ClearBackground(skyColorBlue);

            // Drawing variables for mouse location 
            float xMouseLocation = Input.GetMouseX();
            float yMouseLocation = Input.GetMouseY();

            // For statement for drawing stars onto screen 
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                // Only draw if the star is visible on the screen
                if (starVisibility[i])
                {
                    // Color the stars 
                    Draw.FillColor = starColorCyan;

                    // Variables for checking to see if x and y are on one of the stars 
                    float isMousePositionXOnStar = xMouseLocation - xCoordinates[i];
                    float isMousePositionYOnStar = yMouseLocation - yCoordinates[i];

                    // Varible for detecting if mouse location is on a star 
                    float distanceFromCenterOfStar = (isMousePositionXOnStar * isMousePositionXOnStar) + (isMousePositionYOnStar * isMousePositionYOnStar);

                    // Checks to see if mouse is within star radius
                    if (distanceFromCenterOfStar <= starRadius * starRadius)
                    {
                        // If left click is clicked withgin the radius remove the star 
                        if (Input.IsMouseButtonPressed(MouseInput.Left))
                        {
                            // Removes the star from screen 
                            starVisibility[i] = false;

                            // Adds to click counter 
                            clickCount++;
                        }

                    }

                    // Draw the stars to the screen 
                    Draw.Circle(xCoordinates[i], yCoordinates[i], starRadius);
                }

                // Show landscape photo if player clicks all the stars 
                if (clickCount == 16)
                {
                    NightTimeLandscape();
                }

            }
        }

        // Function for final image displayed
        void NightTimeLandscape()
        {
            // Ramdomly draws stars around the screen 
            Draw.FillColor = starColorCyan;
            for (int i = 0; i < xCoordinatesForRandom.Length; i++)
            {
                Draw.Circle(xCoordinatesForRandom[i], yCoordinatesForRandom[i], starRadius - 7);
            }

            // Draw Moon 
            Draw.FillColor = moonColor;
            Draw.Circle(320, 80, 60);

            // Draw Moon Crevices
            Draw.FillColor = moonCrevices;
            Draw.Circle(300, 50, 20);
            Draw.Circle(350, 60, 20);
            Draw.Circle(310, 110, 20);
            Draw.Circle(280, 80, 10);
            Draw.Circle(350, 100, 10);

            // Draw Ground
            Draw.FillColor = groundColor;
            Draw.Ellipse(200, 375, 500, 100);

        }
    }
}
