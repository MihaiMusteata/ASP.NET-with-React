const API_URL = 'https://localhost:7273';
const API_ENDPOINTS = {
    'LOGIN': `${API_URL}/api/Auth/login`,
    'SIGNUP': `${API_URL}/api/Auth/signup`,
    'LOGOUT': `${API_URL}/api/Auth/logout`,
    'PROFILE': `${API_URL}/api/Auth/profile`,
    'USERS': `${API_URL}/api/Dashboard/users`,
};

export const ApiPostRequest = async (endpoint, data, headers) => {
    const url = API_ENDPOINTS[endpoint];
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(data),
            credentials: 'include',
        });
        console.log('body:', JSON.stringify(data));
        if (response.ok) {
            console.log('Successfully posted data:', response);
            // You might want to redirect the user or perform other actions here
        } else {
            console.error('Failed to post data', response);
        }
    } catch (error) {
        console.error('Error to post data:', error);
    }
};

export const ApiGetRequest = async (endpoint) => {
    const url = API_ENDPOINTS[endpoint];
    const response = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
    });

    if (response.ok) {
        console.log('Successfully fetched data:', response);
        // You might want to redirect the user or perform other actions here
    } else {
        console.error('Failed to fetch data');
        // Handle errors, show error messages, etc.
    }
    return response;
}
