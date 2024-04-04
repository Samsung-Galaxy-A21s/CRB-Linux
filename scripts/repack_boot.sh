#!/bin/bash

echo "Searching for boot.img..."
if [ -e "./Projects/$PROJECT/Build/boot/boot.img" ]; then
	echo "Boot.img Found!"
else
	echo "[Error 1] Boot.img was NOT Found!"
	echo "Check you ran the unpack boot.img script first!"
fi

echo ""

./Projects/$PROJECT/Build/boot/repackimg.sh

echo ""
echo "Copying new boot image to Output folder..."
cp -f ./Projects/$PROJECT/Build/boot/image-new.img ./Projects/$PROJECT/Output/boot.img
echo "Check Output folder for new boot.img"
echo ""

sleep 1
