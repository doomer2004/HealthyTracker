import { useForm } from 'react-hook-form';
import { Box, TextField, Button } from "@mui/material";
import { yupResolver } from '@hookform/resolvers/yup';
import signUpFormValidation from '../../../../validation/forms/SignUpFormFieldsValidation';
import AuthGoogleButton from '../../../google/SignInGoogle';
import { SignUpFormFields } from '../../../../models/form/auth/AuthFormFields';

interface SignUpFormProps {
	onSubmit: (data: SignUpFormFields) => void;
}

const SignUpForm = (props: SignUpFormProps) => {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<SignUpFormFields>({
		resolver: yupResolver(signUpFormValidation),
		reValidateMode: 'onChange',
		mode: 'onTouched'
	});

	return (
		<Box width='500px'>
			<Box
				display={'flex'}
				flexDirection={'column'}
				sx={{ gap: 2, margin: 5, mt: 10, mb: 10 }}
				component="form"
				onSubmit={handleSubmit(props.onSubmit)}>
				<TextField
					id="firstName"
					type="text"
					label="First Name"
					{...register('firstName')}
					error={!!errors.firstName}
					helperText={errors.firstName?.message}
					variant="standard"
					autoComplete='off'
				/>
				<TextField
					id="lastName"
					type="text"
					label="Last Name"
					{...register('lastName')}
					error={!!errors.lastName}
					helperText={errors.firstName?.message}
					variant="standard"
					autoComplete='off'
				/>
				<TextField
					id="email"
					label="Email"
					{...register('email')}
					error={!!errors.email}
					helperText={errors.email?.message}
					variant="standard"
					autoComplete='off'
				/>
				<TextField
					id="password"
					type="password"
					label="Password"
					{...register('password')}
					error={!!errors.password}
					helperText={errors.password?.message}
					variant="standard"
				/>
				<TextField
					id="passwordConfirm"
					type="password"
					label="Confirm Password"
					{...register('confirmPassword')}
					error={!!errors.confirmPassword}
					helperText={errors.confirmPassword?.message}
					variant="standard"
				/>
				<Box
					sx={{
						display: 'flex',
						flexDirection: 'row',
						justifyContent: 'space-evenly',
					}}
				>
					<Button
						type="submit"
						variant="contained"
						color="primary"
						size="large"
						sx={{ width: 'max-content', alignSelf: 'center' }}>
						Sign Up
					</Button>

				</Box>
			</Box>
		</Box>
	);
};

export default SignUpForm;