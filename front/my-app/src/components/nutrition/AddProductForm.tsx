import { yupResolver } from "@hookform/resolvers/yup";
import { Box, TextField, Button } from "@mui/material";
import { AddProductFormFields } from "../../models/form/auth/AddProductFormFields";
import addProductFormValidation from "../../validation/forms/AddProductFormFieldsValidation";
import { useForm } from "react-hook-form";

interface AddProductFormProps {
	onSubmit: (data: AddProductFormFields) => void;
}

export const AddProductForm = (props: AddProductFormProps) => {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<AddProductFormFields>({
		resolver: yupResolver(addProductFormValidation),
		reValidateMode: 'onChange',
		mode: 'onTouched'
	});

	return <Box onClick={(event) => event.stopPropagation()}
		sx={{ width: '100%', height: '10%' }}>
		<Box sx={{ width: '100%', height: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column' }}>
			<form onSubmit={handleSubmit(props.onSubmit)}>
				<TextField
					id="name"
					{...register('name')}
					label="Product Name"
					variant="standard"
					error={Boolean(errors.name)}
					helperText={errors.name?.message}
				/>
				<TextField
					id="volume"
					{...register('volume')}
					label="Volume (g)"
					variant="standard"
					type="number"
					error={Boolean(errors.volume)}
					helperText={errors.volume?.message}
				/>
				<Button
					type="submit"
					variant="contained"
					sx={{ marginTop: '10px' }}>Add</Button>
			</form>
		</Box>

	</Box>;
}