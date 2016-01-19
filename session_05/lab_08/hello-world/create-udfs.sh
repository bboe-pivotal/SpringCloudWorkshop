#!/bin/bash

OLDIFS=$IFS
IFS=$'\n'
entries=$(cf apps | tail -n +5 | awk '{ sub(/,/, ""); print $1, $6}')
for entry in $entries
do
	name=`expr "$entry" : '\([^ ]*\)'`
	hostname=`expr "$entry" : '.* \(.*\)'`

	if [[ "config-server" == "$name" || "service-registry" == "$name" ]]; then
		cf cups $name -p '{"uri":"http://'$hostname'"}'
	fi	

done
