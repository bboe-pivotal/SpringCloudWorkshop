#!/usr/local/bin/bash
# 
# This script requires bash 4! Upgrade!
#
# This script takes in a list of emails (newline seperated) and builds out cf orgs and users. 
# It is assumed that the email takes the form of first_last or first.last. We will create an 
# org named fl-org where f is the first initial and l is the last initial. If we encounter 
# 1 duplcate we will append 1 to the org name. If we encounter two duplicates your in trouble
# this script creates org_summary.txt which is helpful for orienting students about where they 
# should go. 
#
# Before running this script make to set the default behavior of the foundation to be all_closed
# in terms of security groups

# cf create-security-group development-security-group ./development-security-group.json

org=PCF-Training
declare -A space

echo `date` > org_summary.txt
for email in `cat class-participant-emails.txt` ; do
	space=`echo $email | tr '_.' "\n" | egrep -v com | colrm 2 | tr -d "\n"`

	if [[ ${spaces[$space]} -eq 1 ]]; then 
		space=$space"1"
	fi
	space[$space]=1

	echo "INFO: Setting up $space: for $email"
	
	echo cf create-space $space -o $org

	echo cf set-space-role $email $org $space SpaceManager
	echo cf set-space-role $email $org $space SpaceDeveloper

done
