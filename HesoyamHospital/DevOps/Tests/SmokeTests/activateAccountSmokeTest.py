import sys
import requests
import requests.exceptions

ID = -1
ACTIVATION_URL = 'https://hesoyam-hospital.herokuapp.com/api/registration/activate/{}'.format(ID)
TIMEOUT = 10


def main():
    try:
        activation_response = requests.post(ACTIVATION_URL, timeout=TIMEOUT) #We will give it 10 seconds in case our app went to sleep.
    except:
        #If requests module fails to establish connection with the provided URL
        sys.exit(-1)

    #Since we expect this method to return BadRequest we will exit gracefully, otherwise fail with error.
    if activation_response.status_code != 400:
        sys.exit(-1)


if __name__ == "__main__":
    main()

