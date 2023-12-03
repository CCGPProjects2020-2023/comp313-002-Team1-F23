# Asteroid rendering shell script
Inspired on [this tutorial](http://i-simplicity.de/tutorials.html),
uses [povray](http://povray.org/) to render asteroids. Annoyingly povray 
doesn't do parameters, so hence the shell script. I have only run it on linux.

### Useage:
export variables or define them right before the call. Defaults are intended 
to be reasonable. It will also output a file which indicates what the 
parameters where.

### Examples:

    sh asteroid.sh
    size=0.5 sh asteroid.sh
    lz = -800 sh asteroid.lsh

### Variables:

    w,h:       width and height. (800,800)

    size:      size of asteroid(<0.6 ok for otherwise default) (0.5)
    x,y,z:     camera position. (17,0,0)
    angle:     angle of view. (10)
               (has to be tuned with size and x,y,z)
   
    lx,ly,lz:  light source position (500,500,800)
    to_pov:    .pov file to output.  (/tmp/`date +%s`.pov)
    to_png:    .png file to output. (/output/`date +%s`.png)
 
    version:   povray version. (3.7)

## Caveits
Things could be better, no terrible shell-script, it is probably possible, but
difficult, to turn the isosurface into a mesh, and also generate the texture.
But that is a whole project on itself.

There also some 'lines' sometimes when the 'crackle' that adds the craters
superimposes two craters.

# 'Extras'
There is a little shell script to separate alpha from the rest.

## Author
Jasper den Ouden

## License
CC0, or public domain, whichever one chooses.
