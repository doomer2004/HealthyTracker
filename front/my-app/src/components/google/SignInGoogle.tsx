import { useNavigate } from "react-router-dom";
import { useUser } from "../../contexts/UserContext";
import { GoogleLogin, useGoogleLogin } from "@react-oauth/google";
import useNotification from "../../hooks/useNotification";
import { Button } from "@mui/material";
// import { client } from '../../services/api';

const AuthGoogleButton = (props: { label: string, type: 'sign-in' | 'sign-up' }) => {
	const { updateUser } = useUser();
	const { notifyError, Notification } = useNotification();
	const navigate = useNavigate();

	const login = useGoogleLogin({
		onSuccess: async codeResp => {
			console.log(codeResp);
			// var error = await Auth.signInGoogle(codeResp.code);
			// if (!error) {
			// 	const user = await Auth.me();
			// 	if (user) {
			// 		updateUser(user);
			// 		navigate('/');
			// 	} else {
			// 		notifyError('Error during signing in');
			// 	}
			// }
			// else {
			// 	notifyError(error?.message ?? 'Error during signing in');
			// }
		},
		flow: 'auth-code'
	});

	const register = useGoogleLogin({
		onSuccess: async codeResp => {
			console.log(codeResp);
			// await client.signUp2(codeResp.code);
			// if (!error) {
			// 	const user = await client.me();
			// 	if (user)
			// 		updateUser(user);
			// 	else
			// 		notifyError('Error during signing up');
			// 	navigate('/');
			// }
			// else {
			// 	notifyError(error?.message ?? 'Error during signing up');
			// }
		},
		flow: 'auth-code'
	});

	return (
		<>
			<Notification />
			<GoogleLogin
				onSuccess={props.type === 'sign-in' ? login : register}
				onError={() => notifyError('Error during signing in')}
			/>
		</>
	);
}

export default AuthGoogleButton;
