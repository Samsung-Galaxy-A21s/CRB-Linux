#!/bin/bash

# Script to resize a partition

BOLD_GREEN='\033[1;32m'
BOLD_RED='\033[1;31m'
BOLD_RED='\033[1;31m'
BOLD='\033[1m'
RESET='\033[0m' # Reset color

echo ""
if [ -e "./Projects/$PROJECT/Input/super.img.raw" ]; then
    :
else
    echo "[Error 1] Image Data NOT Located!"
    echo "Make sure you have unpacked a super.img first!"
    sleep 2
    exit 0
fi

SYSTEM_SIZE=$(du -b ./Projects/$PROJECT/Output/system.img | awk '{print $1}')
PRODUCT_SIZE=$(du -b ./Projects/$PROJECT/Output/product.img | awk '{print $1}')
VENDOR_SIZE=$(du -b ./Projects/$PROJECT/Output/vendor.img | awk '{print $1}')
ODM_SIZE=$(du -b ./Projects/$PROJECT/Output/odm.img | awk '{print $1}')

TOTAL_SIZE=$(echo "$SYSTEM_SIZE + $PRODUCT_SIZE + $VENDOR_SIZE + $ODM_SIZE" | bc)
SUPER_SIZE=$(du -b ./Projects/$PROJECT/Input/super.img.raw | awk '{print $1}')

echo -e "Partions:
    ${BOLD_GREEN}1. system
    2. vendor
    3. product
    4. odm
    5. prism
    6. optics${RESET}
    "
read -p "Which partition would you like to resize?: " PARTITION

if [ $PARTITION == 1 ]; then
    if [ -e "./Projects/$PROJECT/Output/system.img" ]; then
        IMAGE="./Projects/$PROJECT/Output/system.img"
    else
        echo "[Error 1] System.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
        exit 0
    fi
elif [ $PARTITION == 2 ]; then
    if [ -e "./Projects/$PROJECT/Output/vendor.img" ]; then
        IMAGE="./Projects/$PROJECT/Output/vendor.img"
    else
        echo "[Error 1] Vendor.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
        exit 0
    fi
elif [ $PARTITION == 3 ]; then
    if [ -e "./Projects/$PROJECT/Output/product.img" ]; then
        IMAGE="./Projects/$PROJECT/Output/product.img"
    else
        echo "[Error 1] Product.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
        exit 0
    fi
elif [ $PARTITION == 4 ]; then
    if [ -e "./Projects/$PROJECT/Output/odm.img" ]; then
        IMAGE="./Projects/$PROJECT/Output/odm.img"
    else
        echo "[Error 1] Odm.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
        exit 0
    fi
elif [ $PARTITION == 5 ]; then
    if [ -e "./Projects/$PROJECT/Output/prism.img" ]; then
        IMAGE="./Projects/$PROJECT/Output/prism.img"
    else
        echo "[Error 1] Prism.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
        exit 0
    fi
elif [ $PARTITION == 6 ]; then
    if [ -e "./Projects/$PROJECT/Output/optics.img" ]; then
        IMAGE="./Projects/$PROJECT/Output/optics.img"
    else
        echo "[Error 1] Optics.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
        exit 0
    fi
else
    echo ""
    echo "[Error 1] Invalid option!"
    sleep 1.5
    exit 1
fi

read -p "How much would you like to increase this partition by (in MB)?: " INCREASE_SIZE_MB

if [ $((TOTAL_SIZE + (INCREASE_SIZE_MB * 1024 * 1024))) -gt $SUPER_SIZE ]; then
    echo "Increase size exceeds super image size!"
    sleep 3
    exit 1
else
    echo ""
    echo "Increasing partition by $INCREASE_SIZE_MB MB..."
    echo ""
fi

# Unmount all partitions
sudo umount Projects/*/Build/system > /dev/null 2>&1
sudo umount Projects/*/Build/product > /dev/null 2>&1
sudo umount Projects/*/Build/vendor > /dev/null 2>&1
sudo umount Projects/*/Build/odm > /dev/null 2>&1
sudo umount Projects/*/Build/prism > /dev/null 2>&1
sudo umount Projects/*/Build/optics > /dev/null 2>&1

# Set the block size
BLOCK_SIZE=4096

# Calculate the number of blocks to add
INCREASE_SIZE_BYTES=$((INCREASE_SIZE_MB * 1024 * 1024))
BLOCK_COUNT=$((INCREASE_SIZE_BYTES / BLOCK_SIZE))

# Increase the size of the image
dd if=/dev/zero bs=${BLOCK_SIZE} count=${BLOCK_COUNT} >> ${IMAGE}

# Attach the image to a loop device
LOOP_DEVICE=$(sudo losetup -fP --show ${IMAGE})
echo "Image attached to ${LOOP_DEVICE}"

# Resize the filesystem
sudo e2fsck -f ${LOOP_DEVICE}
sudo resize2fs ${LOOP_DEVICE}

# Detach the loop device
sudo losetup -d ${LOOP_DEVICE}
echo "Filesystem resized and loop device detached"
echo ""
echo "Done!"
sleep 2
