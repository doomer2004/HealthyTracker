import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import {GoogleOAuthProvider} from "@react-oauth/google";
const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <GoogleOAuthProvider clientId="369545641258-96ctrh5m3bovh8l9pgt6aammr3rbhqa8.apps.googleusercontent.com">
    <React.StrictMode>
        <App />
    </React.StrictMode >
    </GoogleOAuthProvider>
);