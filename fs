#!/bin/bash
source $toolbin/basic-method
if [ "$1" ]; then
	echo "++++++++++++++++++++++++Force closing $1 ++++++++++++++++++++++++"
	if [ "$dev" ]; then
        check_device
        adb -s $dev shell am force-stop $1
    else
        adb shell am force-stop $1
    fi
else
	echo "++++++++++++++++++++++++OOPS:(  Please tell me which pkg! ++++++++++++++++++++++++"
fi
#echo $dev;
