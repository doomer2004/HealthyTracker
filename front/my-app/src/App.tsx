import Layout from "./components/layout/Layout";
import Home from "./components/pages/Home";
import React, {FC} from "react";
import SignIn from "./components/pages/Auth/SignInPage";
import {Routes, Route, BrowserRouter} from "react-router-dom";
const layout = {

}

const App: FC = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/sign-in" element={<SignIn />} />

                <Route path="*" element={<h1 style={{ color: 'red' }} >Not Found</h1>} />
            </Routes>
        </BrowserRouter>
    )
}

export default App;