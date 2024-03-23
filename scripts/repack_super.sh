#!/bin/bash
# Script to repack super.img

echo "Building Super Image..."
echo ""
_OUTPUT=./Projects/$PROJECT/Output
./tools/super_to_raw/lpmake --metadata-size 65536 --super-name super --metadata-slot 1 --device super:6131421184 --group main:5721821184 --partition system:readonly:4008112128:main --image system=$_OUTPUT/system.img --partition product:readonly:1139265536:main --image product=$_OUTPUT/product.img --partition vendor:readonly:569839616:main --image vendor=$_OUTPUT/vendor.img --partition odm:readonly:4603904:main --image odm=$_OUTPUT/odm.img --sparse --output $_OUTPUT/super.img
echo ""

echo "Done!"

