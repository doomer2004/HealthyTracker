
import Home from "./components/pages/Home";
import React, { FC } from "react";
import SignUp from "./components/pages/Auth/SignUp";
import { Routes, Route, BrowserRouter } from "react-router-dom";
import SignIn from "./components/pages/Auth/SignIn";
import About from "./components/pages/About";
import NutritionCalculator from "./components/pages/Nutrition/NutritionCalculator";
import ChangePassword from "./components/pages/Auth/ChangePassword";
import UserActivation from "./components/pages/User/UserAccount";
import RemaindPassword from "./components/pages/Auth/RemaindPassword";
import MyNutrition from "./components/pages/MyNutrition";
import { UserProvider } from './contexts/UserContext';
const layout = {

}

const App: FC = () => {
    const responseMessage = (response: any) => {
        console.log(response);
    };
    const errorMessage = (error: any) => {
        console.log(error);
    };
    return (
        <BrowserRouter>
            <UserProvider>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/sign-in" element={<SignIn />} />
                    <Route path="/sign-up" element={<SignUp />} />
                    <Route path="/about" element={<About />} />
                    <Route path="/nutrition-calculator" element={<NutritionCalculator />} />
                    <Route path="/{id}/change-password" element={<ChangePassword />} />
                    <Route path="/{id}/user-account" element={<UserActivation />} />
                    <Route path="/remaind-password" element={<RemaindPassword />} />
                    <Route path="/id/my-nutrition" element={<MyNutrition />} />
                    <Route path="*" element={<h1 style={{ color: 'red' }} >Not Found</h1>} />
                </Routes>
            </UserProvider>
        </BrowserRouter>
    )
}

export default App;