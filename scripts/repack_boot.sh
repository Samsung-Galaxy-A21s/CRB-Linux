#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/boot/boot.img" ]; then
	echo ""	
	echo "Boot.img Found!"
else
	echo ""
	echo "[Error 1] Boot.img data NOT Found!"
	echo "Check you have unpacked a boot image first!"
	sleep 2
	exit 0
fi

echo ""

rm -rf ./Projects/$PROJECT/Build/boot/image-new.img
./Projects/$PROJECT/Build/boot/repackimg.sh

echo ""
cp -f ./Projects/$PROJECT/Build/boot/image-new.img ./Projects/$PROJECT/Output/boot.img
echo "Check ./Projects/$PROJECT/Output for a new boot.img"
echo ""

sleep 1
