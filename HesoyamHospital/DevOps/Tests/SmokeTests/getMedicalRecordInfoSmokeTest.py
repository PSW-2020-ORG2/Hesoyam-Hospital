import sys
import requests
import requests.exceptions

GET_MEDICAL_RECORD_URL = 'https://hesoyam-hospital.herokuapp.com/api/medicalrecord/show/{}'.format(MEDICAL_RECORD_ID)
TIMEOUT = 10

def main():
    try:
        get_medical_record_response = requests.get(GET_MEDICAL_RECORD_URL, timeout = TIMEOUT)
    except:
         #If requests module failed to establish connection with the URL provided.
        sys.exit(-1)

    if get_medical_record_response.status_code != 404:
        sys.exit(-1)
    

    #otherwise exit with ok



if __name__ == "__main__":
    main()