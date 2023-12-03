#!/bin/bash
#Gets only the alpha channel.
#Arguments: input file, output file.

#thanks to 
#http://www.wizards-toolkit.org/discourse-server/viewtopic.php?f=1&t=10155&start=0#p32071

convert $1 -channel matte -negate -separate +matte $2
