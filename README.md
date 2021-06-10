# TechnicalTest
My approach was to build the basic game mechanics around art that would convey the final, kid-friendly tone of the product.
All art was from free-to-use clipart found online.

Some issues that would need to be addressed:
  * It was not specified the input method of the game so I defaulted to simple keyboard input, using the old Unity Input manager.
  * No object pooling (objects are instantiated and destroyes as needed).
  * Fish only spawn one at a time and only from one direction.
  * Fish have boring, predictable behaviour.
  * When eating a fish, the player shark "bounces", do to the use of dynamic bodies.
  * I had an issue with the window size changing every time the game was run. This may be due to me having two monitors at different resolutions.
  
Improvements that could be made:
  * Better controls - the target platform would most likely be tablet, so touch controls would need to be implemented, which would fundamentaly change how the character moves.
  * Fish behaviour - my original idea was to have the fish swim away from the player, either off screen or behind the scenery.
  * More varieties of fish, more interesting spawning of fish (ex: more at once, different speeds).
  * I wanted to have the shark "rush" towards a fish when it was close to a fish to get a more dynamic, exciting feel.
  * Unity rigidbody 2D physics is hard to tame and unsatisfying to play. For a game like this "realistic" physics is not required, so I would favour kinematic bodies over dynamic. 
  * More visual and audio feedback.
  
