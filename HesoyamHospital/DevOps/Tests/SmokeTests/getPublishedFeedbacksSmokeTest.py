import sys
import requests
import requests.exceptions

def main():
    GET_PUBLISHED_URL = 'https://hesoyam-hospital.herokuapp.com/api/feedback/published'
    TIMEOUT = 10

    try:
        response = requests.get(GET_PUBLISHED_URL, timeout = TIMEOUT)
    except:
        #If requests module failed to establish connection with the URL provided.
        sys.exit(-1)

    try:
        response.raise_for_status()
    except HttpError:
        #If we got one of the http error status codes, exit with an error
        sys.exit(-1)

if __name__ == "__main__":
    main()

#Otherwise finish script