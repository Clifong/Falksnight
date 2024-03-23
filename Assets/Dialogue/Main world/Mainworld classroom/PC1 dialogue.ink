EXTERNAL ExitDialogueEventSpecial()

Oh hey! What should we do? #pc1_happy

-> choice

=== choice ===

+ [Let's enter your mind]
    ~ExitDialogueEventSpecial()
    -> outcome1

+ [How are you feeling?]
    -> outcome2
    
+ [I'll come back later. Gotta do something first]
    -> outcome3
    
=== outcome1 ===
-> END

=== outcome2 ===
It feels a bit weird entering my own head. It feels like you're dreaming. #pc1_neutral

Sometimes in there, I can choose to switch around. For example, I could be controlling my own "body" here. And on the other hand, I can choose to control my body outside. #pc1_neutral

... On second thought, do you think people will find it work if someone is standing still with their eyes closed? #pc1_neutral

-> outcome2_1

=== outcome2_1 ===

+ [It's certainly odd]
    -> outcome2_1_1
    
+ [We gotta find some other place...]
    -> outcome_2_1_2
    
=== outcome2_1_1 ===
Yeah... We need to find somewhere else next time we do this. #pc1_neutral

-> choice

=== outcome_2_1_2 ====
Yeah... We need to find somewhere else next time. But I wonder where? #pc1_neutral

Maybe you can try my house. #pc1_neutral

-> choice

=== outcome3 === 
oh alright, see you. But please don't be gone for too long, it feels a bit weird staying here on my own. #pc1_happy

-> END

== function ExitDialogueEventSpecial() ==
~ return 0


