# Gesture Based UI Project
## Purpose of the application:
The purpose of this application is to have intuitively control game using gesture based inputs. We started with deciding on what gesture based device we wanted to learn more about, We choose myo due to the fact that it has a wide variety of gestures we could use like hand gestures, arm movement and arm rotation. Then we looked at a few different games and thought about what kind of gestures could possibly work well with each game, we decided on space invaders as our game since the controls are simple and can be easily mapped to the myo.

Before we actually started on the game with got a myo and it installed the myo sdk, we then used the same scenes and scripts that came with the sdk to get a better understanding of how the myo works. We broke the code from the sample scripts into different parts to test what code controlled the certain aspects of how the myo controls the game object in unity. We did this because myo didn't have many resources online to learn from.

We created a basic versions of our game and implemented what we learned from the sample code. Originally we incorporated the myo's simple hand gestures to control the player and menu, it quickly became apparent that the hand gesture were unreliable and took to much time to switch between gestures to able to smoothly control the player. As a result of these problems we switch to the myo's ability to track the motion of the users arm to control the player, this way of control did work better than hand gestures but came with its own problems. The arm movement had to be very apparent for the myo to be able to pick it up. The user had to swing their arm left and right to get the player to move, overtime this be came quite tiring and didn't feel natural. Finally we tried using the myo's gyroscope to allow us to use the user's hand rotation, this revealed itself to be the best match for our game due to its quick reponse and the minimal strain it put on the user. The hand rotation also allowed us to have a dead space in the middle to allow the user to stop. 

While testing the game with the myo we came to the conclusion that the myo hand gestures were to unreliable and frustrating to use for the menu, instead we decided to add speech recognition for the menu and pause menu. We felt that the addtion of speech recognition allowed for a more intuitive and immersive experience. 

## Gestures identified as appropriate for this application:
When choosing what gestures to incorporate into our game we decided that the gestures had to live up to a certain standard:
  - Intuitive
  - Reliable
  - Responsive 
  - Minimal Strain

| Main Menu | Intuitive | Reliable | Responsive | Minimal Strain |
| ------ | ------ | ------ | ------ | ------ | 
| Hand Gestures | Y | N | N | Y |
| Arm Tracking | N/A | N/A | N/A | N/A |
| Hand Rotation | N/A | N/A | N/A | N/A |
| Speech Recognition | Y | Y | Y | Y |
>Conclusion: Speech Recognition is the clear choice for the Main Menu, Hand Gestures just aren't as reliable and responsive are the speech recognition. 

| Player Movement | Intuitive | Reliable | Responsive | Minimal Strain |
| ------ | ------ | ------ | ------ | ------ | 
| Hand Gestures | Y | N | N | N |
| Arm Tracking | Y | N | N | N |
| Hand Rotation | Y | Y | Y | Y |
| Speech Recognition | N/A | N/A | N/A | N/A |
>Conclusion: Hand Rotation is by far the best movement option for the player, It's extremely reliable and responive while put minimal strain on the user. 

| Player Shooting | Intuitive | Reliable | Responsive | Minimal Strain |
| ------ | ------ | ------ | ------ | ------ | 
| Hand Gestures | Y | Y | N | Y |
| Arm Tracking | N | N | N | N |
| Hand Rotation | N/A | N/A | N/A | N/A |
| Speech Recognition | Y | N | N | Y |
>Conclusion: Hand Gestures are the best option but still arn't perfect, it is very intuitve but falls short when it comes to reliability and responsiveness. The Speech Recognition is reliable and responsive enough for the menus but during a fast pace game it's lacking.

| Pause Menu | Intuitive | Reliable | Responsive | Minimal Strain |
| ------ | ------ | ------ | ------ | ------ | 
| Hand Gestures | Y | N | N | Y |
| Arm Tracking | N/A | N/A | N/A | N/A |
| Hand Rotation | N/A | N/A | N/A | N/A |
| Speech Recognition | Y | Y | Y | Y |
>Conclusion: Speech Recognition work well with the pause menu, Being able to simply say pause while still controlling the player means there is little chance of making a mistake while just trying to pause. It's extremely intuitive and puts no strain on the player, it may not be that responsive but since it doesn't impede the user from controlling the player the short delay between when you say pause and when it actually pauses doesnt matter. 

#### Final Controls:
Myo Controls:
![Controls](https://i.imgur.com/7crAhgM.jpg)

Voice Controls:

| Main Menu | Commands |
| ------ | ------ |
| Start Game | Start |
| Tutorials | Help |
| Quit Game | Quit |

| Pause Menu | Commands |
| ------ | ------ |
| Pause Game | Pause |
| Unpause Game | Play |
| Return to Main Menu | Return |

|  Tutorial/Game Over Menu | Command |
| ------ | ------ |
| Return to Main Menu | Main |

## Hardware used in creating the application:
***Myo:*** "The Myo armband lets you use the electrical activity in your muscles to wirelessly control your computer, phone, and other favourite digital technologies. With the wave of your hand, it will transform how you interact with your digital world." 

Their are a few reasons why we picked myo as our main piece of hardware, our primary reason was because the myo has multiple way for us to control our player, which allowed us to have the most intuitive and reactive experience possible. The final reason we picked the myo was because it was the one device that we were both interested in using and learning more about.

***Microphone:*** "Windows Speech Recognition lets you control your PC with your voice alone, without needing a keyboard or mouse."

After it became apparatent that the myo wasn't as reliable as we would have like we decided to intergrate voice recognition for areas that the myo just wasnt up to scratch. This lead to a more immersive and intuitive experience.

## Architecture for the solution:
![Layout](https://i.imgur.com/HGh2IVk.png)

## Video Demonstration
[![Watch the video](https://media.giphy.com/media/13Nc3xlO1kGg3S/giphy.gif)](https://www.youtube.com/watch?v=noFBJ0wuRxs)

## Conclusions & Recommendations:
***Conclusions:***
Throughout the course of this project we have learn a lot, for example we should have researched more about what resources were available for the potential hardware we were going to use. we spent a considerable amount of time try to get the Myo working due to the lack of resources available online since the creators of the Myo stopped supporting it. The Myo is an interesting product but without the support of the creators and the fact that it is discontinued means that it is very limited when developing with. 

***Recommendations:***
Our recommendations is that during the research process the main focus shouldn't just be on what the hardware can do, part of the research process should also look into what resource are available.

***Reflective:***
On reflection we have learned quite a bit, Learning how to control the Myo through some simple code provided by the sdk was challenging but also provied us with a new way of learn about hardware, I think in the end we came to a better understanding of the Myo then we would have if we had more resources online.

We also learn about creative solutions when it comes to hardware limitations, whether it be using a different aspect of the hardware or using a different hardware to cover the downfall of the original piece of hardware

## How to Run:
What you need:

  - Windows Device
  
  - Myo armband
  
Then Run the executable.
