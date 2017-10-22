# ISWT
Item Stat Weight Tool


I've created a tool to optimize gear based on stat values.

You can set your personal stat values on the right side and the minimum requirement the full gear should have on the left side.

Click on the optimize button to get the best 15 gear results. Be aware that it takes my PC 130 seconds to calculate the results - so if you add more items try to delete inferior ones to speed up the process.

Enchants get optimized too so it takes Core Armor Kits(+3 Def), Librams (+100 health) etc. into account. Hover over the items with your mouse to see which enchant you should use on it.

[img overlay=true]http://i.imgur.com/zvVVQzB.jpg[/img]


As a tank you need +140 def to reach def cap. With +10 from talents and +15 from your shield you should set the minimum defense requirement to 115 to find the best gear while still being def capped.

[img overlay=true]http://i.imgur.com/l36iMwy.jpg[/img]


If you want to get the best gear for tanking Ragnaros (you want to be fire resistance capped) you need 240 fire resistance from your gear (+60 from shaman totem and +15 from juju ember).
So including your shield with +10 fire res you need to set the minimum fire resistance requirement to 230 to find the best fire resistance gear (220 if you have Alcor's).


How to change / update items:
If you want to change items use the Items.xlsx Excel file.
The first row describes what slot the items fits in, its name and what stats it has.
In the second row you can set the stat weights. 
',' will automatically get changed into '.'

When you are done editing it press the following two buttons while you have the excel file still opened: 
'ctrl' 'a'
now every column and row should be marked. Now press:
'ctrl' 'c'

Now open the Items.txt Text file and press:
'ctrl' 'a'
Now press:
'ctrl' 'v'

You should now see your updated items from your excel file in the text file, seperated by tabs.
Close the program and open it again - if you don't see an error message your new items should have loaded correctly.


Performance tips:
1. Try to use the least amount of items & enchants.
2. Setup a minimum requirement for at least one stat. Setting a minimum of 115 defense reduces the time my PC takes from 130 to 26 seconds!
