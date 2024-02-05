import React, { useEffect, useState } from 'react';
import { ApiGetRequest } from '../actions/api';
import Cookie from 'js-cookie';

const Weather = () => {
    useEffect(() => {
        // Access and manipulate cookies here
        const token = Cookie.get('XKey');
        console.log(token);
    
        // Cleanup function if necessary
        return () => {
          // Cleanup logic here if needed
        };
      }, []); // Empty dependency array ensures the useEffect runs only once
    
    return (
        <div>
            <h1>Weather</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {/* <pre>{JSON.stringify(responseData, null, 2)}</pre> */}
        </div>
    );
};
export default Weather;