import React, { useEffect, useState } from 'react';
import { ApiPostRequest } from '../actions/api';
import { Container, Button } from 'react-bootstrap';
import Cookie from 'js-cookie';
import { useNavigate } from 'react-router-dom';
import '../styles/auth.css';



function Authentication() {
    const [isSignUpActive, setSignUpActive] = useState(true);

    const handleSignUpClick = () => {
        setSignUpActive(true);
    };

    const handleSignInClick = () => {
        setSignUpActive(false);
    };
    const handleSignUp = async () => {
        var email = document.getElementById('email').value;
        var username = document.getElementById('username').value;
        var password = document.getElementById('password').value;
        var confirmPassword = document.getElementById('confirm-password').value;
        var gender = document.getElementById('gender').value;

        var data = {
            email: email,
            username: username,
            password: password,
            confirmPassword: confirmPassword,
            gender: gender,
            loginIp: 'string',
            loginDateTime: '2021-06-01T14:00:00.000Z',
        };
        await ApiPostRequest('SIGNUP', data, { 'Content-Type': 'application/json' });
    }

    const handleSignIn = async () => {
        var email = document.getElementById('credential').value;
        var password = document.getElementById('login-password').value;

        var data = {
            credential: email,
            password: password
        };
        await ApiPostRequest('LOGIN', data, { 'Content-Type': 'application/json' });
        
    const token = Cookie.get('X-Key');

    console.log(token);
    }




    return (
        <div className='authentication'>
            <div className={`auth-container ${isSignUpActive ? 'right-panel-active' : ''}`}>
                <div className="form-container sign-up-container">
                    <form action="#">
                        <h1>Create Account</h1>
                        <span>or use your email for registration</span>
                        <input type="email" placeholder="Email" id="email" />
                        <input type="text" placeholder="Username" id="username" />
                        <input type="password" placeholder="Password" id="password" />
                        <input type="password" placeholder="Confirm Password" id="confirm-password" />
                        <input type="text" placeholder="Gender" id="gender" />
                        <button onClick={handleSignUp}>Sign Up</button>
                    </form>
                </div>
                <div className="form-container sign-in-container">
                    <form action="#">
                        <h1>Sign in</h1>
                        <span>or use your account</span>
                        <input type="email" placeholder="Email" id="credential" />
                        <input type="password" placeholder="Password" id="login-password" />
                        <a href="#">Forgot your password?</a>
                        <button onClick={handleSignIn} href="/dashboard">Sign In</button>
                    </form>
                </div>
                <div className="overlay-container">
                    <div className="overlay">
                        <div className="overlay-panel overlay-left">
                            <h1>Welcome Back!</h1>
                            <p>To keep connected with us please login with your personal info</p>
                            <button className="ghost" onClick={handleSignInClick}>Sign In</button>
                        </div>
                        <div className="overlay-panel overlay-right">
                            <h1>Hello, Friend!</h1>
                            <p>Enter your personal details and start journey with us</p>
                            <button className="ghost" onClick={handleSignUpClick}>Sign Up</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};
export default Authentication;