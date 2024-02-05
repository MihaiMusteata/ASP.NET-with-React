import React, { useEffect, useState } from 'react';
import { ApiRequest } from '../actions/api';
import { Container, Button } from 'react-bootstrap';
import '../styles/welcome.css';

const Welcome = () => {
    return (
        <div className='welcome'>
            <Container className="welcome-container" >
                <h1 className='title'>👋🏻 Bun Venit pe Site!</h1>
                <p>Task realizat in ASP.NET cu React</p>
            </Container>
            <Button className='welcome-btn' href="/authentication">Să Începem</Button>
        </div>
    );
};
export default Welcome;