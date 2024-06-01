#!/bin/bash
# Script to repack super.img

# Check that the user has actually unpacked a super.img
if [ -f "./Projects/$PROJECT/Output/system.img" ] && [ -f "./Projects/$PROJECT/Output/product.img" ] && [ -f "./Projects/$PROJECT/Output/vendor.img" ] && [ -f "./Projects/$PROJECT/Output/odm.img" ]; then
    echo ""
    echo "Super.img data detected!"
else
    echo ""
    echo -e "${BOLD_RED}[Error 1] Super.img data NOT DETECTED!"
    echo -e "Please Unpack a super.img first!"
    echo -e "*hint* Also check the partitions are mounted!${RESET}"
    sleep 2
    exit 0
fi

echo "Building Super Image..."
echo ""

# Regardless we will remove any old builds
echo "Cleaning any old builds..."
rm -rf ./Projects/$PROJECT/Output/super.img

echo "Unmounting partitions..."
echo ""

# Un mount mounted partitions
sudo umount Projects/$PROJECT/Build/system > /dev/null 2>&1
sudo umount Projects/$PROJECT/Build/product > /dev/null 2>&1
sudo umount Projects/$PROJECT/Build/vendor > /dev/null 2>&1
sudo umount Projects/$PROJECT/Build/odm > /dev/null 2>&1

# Calculate sizes
SYSTEM_SIZE=$(du -b ./Projects/$PROJECT/Output/system.img | awk '{print $1}')
PRODUCT_SIZE=$(du -b ./Projects/$PROJECT/Output/product.img | awk '{print $1}')
VENDOR_SIZE=$(du -b ./Projects/$PROJECT/Output/vendor.img | awk '{print $1}')
ODM_SIZE=$(du -b ./Projects/$PROJECT/Output/odm.img | awk '{print $1}')
BLOCK_SIZE=$(stat -f ./Projects/$PROJECT/Input/super.img.raw | grep "Block size:" | awk '{print $3}')

# Convert sizes to blocks
CALCULATED_SYSTEM_SIZE=$(echo "($SYSTEM_SIZE / $BLOCK_SIZE)" | bc)
CALCULATED_PRODUCT_SIZE=$(echo "($PRODUCT_SIZE / $BLOCK_SIZE)" | bc)
CALCULATED_VENDOR_SIZE=$(echo "($VENDOR_SIZE / $BLOCK_SIZE)" | bc)
CALCULATED_ODM_SIZE=$(echo "($ODM_SIZE / $BLOCK_SIZE)" | bc)

# Calculate the Total amount of blocks, and the MAIN_SIZE in which the main partitions will go
TOTAL_BLOCKS=$(echo "$CALCULATED_SYSTEM_SIZE + $CALCULATED_PRODUCT_SIZE + $CALCULATED_VENDOR_SIZE + $CALCULATED_ODM_SIZE" | bc)

# This tells us exact size we need in bytes
MAIN_SIZE=$(echo "$TOTAL_BLOCKS * $BLOCK_SIZE" | bc)

# Calculate the size of the super image
SUPER_SIZE=$(du -b ./Projects/$PROJECT/Input/super.img.raw | awk '{print $1}')


# Build the super image
_OUTPUT=./Projects/$PROJECT/Output
./tools/super_to_raw/lpmake --metadata-size 65536 \
    --block-size=$BLOCK_SIZE \
    --super-name super \
    --metadata-slot 1 \
    --device super:$SUPER_SIZE \
    --group main:$MAIN_SIZE \
    --partition system:readonly:$SYSTEM_SIZE:main \
    --image system=$_OUTPUT/system.img \
    --partition product:readonly:$PRODUCT_SIZE:main \
    --image product=$_OUTPUT/product.img \
    --partition vendor:readonly:$VENDOR_SIZE:main \
    --image vendor=$_OUTPUT/vendor.img \
    --partition odm:readonly:$ODM_SIZE:main \
    --image odm=$_OUTPUT/odm.img \
    --output $_OUTPUT/super.img

# Check if the command succeeded
if [ $? -eq 0 ]; then
    
    echo ""
    echo "Check Projects/$PROJECT/Output for super.img"
    echo "Done!"

    sleep 1
else
    echo ""
    echo -e "${BOLD_RED}[Error 1] Super.img failed to build!"
    echo -e "If it is failing at this stage, it is likely some of the Images,
          don't fit into the super partition, as so please raise an issue on github!${RESET}"
    sleep 1
fi

