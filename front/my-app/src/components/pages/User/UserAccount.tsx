import React from "react";
import Layout from "../../layout/Layout";
import { Avatar, Box, Button, Card, Paper, Typography } from "@mui/material";
import { IUserData } from "./types";
import "../../../styles/pages/userAccount.css"
const UserAccount = () => {

	const userData: IUserData = {
		firstName: "123",
		lastName: "123",
		email: "123",
	}
	return (
		<Layout>
			<Box className="main">
				<Box className="main-avatar">
					<Avatar
						alt="Remy Sharp"
						src=""
						sx={{ width: 200, height: 200 }}
						onClick={() => { console.log("click") }}
					/>
				</Box>
				<Box className="main-info">

					<Paper elevation={1} className="main-info-paper">{userData.firstName}</Paper>
					<Paper elevation={1} className="main-info-paper">{userData.lastName}</Paper>
					<Paper elevation={1} className="main-info-paper">{userData.email}</Paper>
				</Box>
			</Box>
			<Box className="main-buttons">
				<Button variant="contained" onClick={() => (console.log("click"))}>Edit profile</Button>
			</Box>
		</Layout >
	)
}

export default UserAccount

//TODO make logout works
//TODO make login works
//TODO make check is user logged in on goal page
//TODO Make handler for 401 with redirect on login
//TODO OPTIONAL remove all trnasfer of user Id from models urls ect