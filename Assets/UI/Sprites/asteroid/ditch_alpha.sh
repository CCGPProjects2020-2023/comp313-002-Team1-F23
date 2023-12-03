#!/bin/bash
#Gets rid of the alpha channel.
#Arguments: input file, output file.

convert -alpha opaque $1 $2
