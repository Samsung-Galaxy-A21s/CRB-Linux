#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/boot/boot.img" ]; then
	echo "Boot.img Found!"
else
	echo "[Error 1] Boot.img was NOT Found!"
	echo "Check you have unpacked a boot image first!"
	sleep 2
	exit 0
fi

echo ""

./Projects/$PROJECT/Build/boot/repackimg.sh

echo ""
echo "Copying new boot image to Output folder..."
cp -f ./Projects/$PROJECT/Build/boot/image-new.img ./Projects/$PROJECT/Output/boot.img
echo "Check Output folder for new boot.img"
echo ""

sleep 1
