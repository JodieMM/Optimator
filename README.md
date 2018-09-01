# Optimator

All
	Ø Proper comments (///)
	Ø Check buttons/features all working properly
	Ø Change from Panel to PictureBox?
	Ø Sprites menu option
	Ø X button not losing everything (without checking first- does same as 'Done' button)
	Ø Decals (inner piece parts that can be connected to piece coordinates)
		○ Points connected to that piece show up (in sets, but need to update point naming to work)
		○ Also, add multiple points in succession? "Do you want to add another point?"
	Ø Constants file (folder names etc.)
	Ø Stop file names containing ; : and , and stop pieces from ending in the new point naming scheme
	Ø Ability to go backwards/forwards (Ctrl + Z/ Ctrl + Shift + Z)


Pieces/ PiecesForm
Desired:
	Ø Visual representation of coordinates covered
		○ Next Angle button needs to be based on original data (corners from above)
	Ø Overriding coordinates
	Ø Mirrors
	Ø Undo/ Redo
	Ø Remove sketches, change sketch size
	Ø Try and save some points if switching to point from piece
	Ø Don't exit save unless name changed
	Ø Delete old pieces/points when switched or name changed
	Ø Loading in pieces select from files not (OR?) manually type in name
	Ø Flexible points
	Ø Sketch option for sets

Considering:
	Ø Adding points to original/rotated/turned adds a corresponding point in the others
		○ Moving points up or down in order ditto
		○ Delete points


Sets/SetsForm
Important:
	Ø Draw sets in an order based on their points (order changes as set moves)
		○ INSTEAD: Can elect a 'switch' angle and at that angle (e.g. 180) the shape will move to the front of the other. It will return back at switch angle + 180 regardless of switch angle.
		○ Need initial 'Front', 'Back' or '[Switch Angle]' status (relates to the thing it is joined to)

Desired:
	Ø Loading in pieces/points/sets select from files not manually type in name
	Ø Change base piece after setting (See swap in considering section)
	Ø Check sets with only one piece load and save correctly

Considering:
	Ø Disallow changing angle/coords for base piece
	Ø Swap functionality for ALL pieces in the set


Scenes/ScenesForm
Important:
	Ø AddSetBtn implement

Desired:
	Ø Ability to move pieces up/down in position (layers)
	Ø Disconnect set option (change belongsTo to null and values to set + their own)
		○ Ability to delete parts of sets (Or set colour to transparent?)
	Ø Ability to hide/show set components

Considering:
	Ø Further actions to implement
		○ Colours/outlines?
	Ø Do we need originals in scene?


Changes/Originals
Desired:
	Ø Colours, outlines, set joins etc. For Originals
		○ Make changes in the first frame (colour, set connectedness etc.)
	Ø Options field for changes (see Changes initialiser)


Compile Video
Important:
	Ø Update to match refactoring

Desired:
	Ø Convert to MP4
