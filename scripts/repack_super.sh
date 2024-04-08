#!/bin/bash
# Script to repack super.img

if [ -f "./Projects/$PROJECT/Output/system.img" ] && [ -f "./Projects/$PROJECT/Output/product.img" ] && [ -f "./Projects/$PROJECT/Output/vendor.img" ] && [ -f "./Projects/$PROJECT/Output/odm.img" ]; then
    echo "Super.img data detected!"
else
    echo "Super.img data NOT DETECTED!"
    echo "Please rebuild all images first!"
    sleep 2
    exit 0
fi

echo "Building Super Image..."
echo ""

rm -rf ./Projects/$PROJECT/Output/super.img

# Re define all of the calculated sizes
SYSTEM_SIZE=$(sudo du -b ./Projects/$PROJECT/Build/system | tail -n 1 | awk '{print $1}')
PRODUCT_SIZE=$(du -b ./Projects/$PROJECT/Input/product.img | awk '{print $1}')
VENDOR_SIZE=$(du -b ./Projects/$PROJECT/Input/vendor.img | awk '{print $1}')
ODM_SIZE=$(du -b ./Projects/$PROJECT/Input/odm.img | awk '{print $1}')
BLOCK_SIZE=$(stat -f ./Projects/$PROJECT/Input/super.img | grep "Block size:" | awk '{print $3}')

CALCULATED_SYSTEM_SIZE=$(echo "($SYSTEM_SIZE / $BLOCK_SIZE) + 41984" | bc)
CALCULATED_PRODUCT_SIZE=$(echo "($PRODUCT_SIZE / $BLOCK_SIZE) + 13056" | bc)
CALCULATED_VENDOR_SIZE=$(echo "($VENDOR_SIZE / $BLOCK_SIZE) + 11776" | bc)
CALCULATED_ODM_SIZE=$(echo "($ODM_SIZE / $BLOCK_SIZE)" | bc)

# Add all 4 variables above together to get total size
TOTAL_BLOCKS=$(echo "$CALCULATED_SYSTEM_SIZE + $CALCULATED_PRODUCT_SIZE + $CALCULATED_VENDOR_SIZE + $CALCULATED_ODM_SIZE + 2" | bc)
MAIN_SIZE=$(echo "$TOTAL_BLOCKS * $BLOCK_SIZE" | bc)
SUPER_SIZE=$(echo "$MAIN_SIZE + 65536" | bc)
echo "Total size of super image: $MAIN_SIZE bytes"

# Multiply calculated sizes by 4096
CALCULATED_SYSTEM_SIZE=$(echo "$CALCULATED_SYSTEM_SIZE * $BLOCK_SIZE" | bc)
CALCULATED_PRODUCT_SIZE=$(echo "$CALCULATED_PRODUCT_SIZE * $BLOCK_SIZE" | bc)
CALCULATED_VENDOR_SIZE=$(echo "$CALCULATED_VENDOR_SIZE * $BLOCK_SIZE" | bc)
CALCULATED_ODM_SIZE=$(echo "$CALCULATED_ODM_SIZE * $BLOCK_SIZE" | bc)

#5639045120

_OUTPUT=./Projects/$PROJECT/Output
./tools/super_to_raw/lpmake --metadata-size 65536 --block-size=$BLOCK_SIZE --super-name super --metadata-slot 1 --device super:5557452800 --group main:$MAIN_SIZE --partition system:readonly:$CALCULATED_SYSTEM_SIZE:main --image system=$_OUTPUT/system.img --partition product:readonly:$CALCULATED_PRODUCT_SIZE:main --image product=$_OUTPUT/product.img --partition vendor:readonly:$CALCULATED_VENDOR_SIZE:main --image vendor=$_OUTPUT/vendor.img --partition odm:readonly:$CALCULATED_ODM_SIZE:main --image odm=$_OUTPUT/odm.img --output $_OUTPUT/super.img
echo ""

echo "Check Projects/$PROJECT/Output for super.img"
echo "Done!"

sleep 1
