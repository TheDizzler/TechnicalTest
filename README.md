# TechnicalTest
My approach was to build the basic game mechanics around art that would convey the final, kid-friendly tone of the product.

Some issues that would need to be addressed:
  It was not specified the input method of the game so I defaulted to simple keyboard input, using the old Unity Input manager.
  No object pooling (objects are instantiated and destroyes as needed).
  Fish only spawn one at a time and only from one direction.
  Fish have boring, predictable behaviour.
  When eating a fish, the player shark "bounces", do to the use of dynamic bodies.
  
Improvements that could be made:
  Better controls - the target platform would most likely be tablet, so touch controls would need to be implemented, which would fundamentaly change how the character moves.
  Fish behaviour - my original idea was to have the fish swim away from the player, either off screen or behind the scenery.
  More varieties of fish, more interesting spawning of fish.
  More visual and audio feedback.
  
