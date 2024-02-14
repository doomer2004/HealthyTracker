import { ChangeEvent, useEffect, useRef } from "react";
import Layout from "../../layout/Layout";
import { Box, Button, Paper } from "@mui/material";
import { IUserData } from "./types";
import "../../../styles/pages/userAccount.css"
import { useUser } from "../../../contexts/UserContext";
import Users from "../../../services/api/Users";
import UploadImage from "../../profile/UploadImage";
const UserAccount = () => {

	const inputFile = useRef(null);
	const { user, refreshUser, loading } = useUser();

	useEffect(() => {
		refreshUser();
	}, []);

	const handleFileUpload = (e: ChangeEvent<HTMLInputElement>) => {
		const { files } = e.target;
		if (files && files.length) {
			Users.uploadAvatar(files[0]).then((response) => {
				console.log('response', response)
				if (response) {
					refreshUser();
				}
			});
		}
	};

	const handleDeleteFile = () => {
		Users.deleteAvatar().then((response) => {
			if (response) {
				refreshUser();
			}
		});
	}

	const userData: IUserData = {
		firstName: user?.firstName || '',
		lastName: user?.lastName || '',
		email: user?.email || '',
	};

	console.log(user)
	return (
		<Layout>
			<Box className="main">
				<Box className="main-avatar">
					<UploadImage
						inputFile={inputFile}
						handleFileUpload={handleFileUpload}
						handleDeleteFile={handleDeleteFile}
						url={user?.avatar ?? ''}
					/>
				</Box>
				<Box className="main-info">

					<Paper elevation={1} className="main-info-paper">First: name: {userData.firstName}</Paper>
					<Paper elevation={1} className="main-info-paper">Last: name {userData.lastName}</Paper>
					<Paper elevation={1} className="main-info-paper">Email: {userData.email}</Paper>
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