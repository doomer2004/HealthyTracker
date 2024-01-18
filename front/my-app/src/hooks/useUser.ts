import { useState, useEffect } from 'react';
import User from '../models/user/User';
import { client } from '../services/api';

const useUser = () => {
    const [user, setUser] = useState<User | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        setLoading(true);

        const fetchUser = async () => {
            const user = await client.me();
            // @ts-ignore
            user ? setUser(user) : logout();
        };

        fetchUser();
        
        setLoading(false);
    }, []);

    const updateUser = (newUser: User) => {
        setUser(newUser);
    };

    const logout = () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        setUser(null);
    };

    return { user, loading, updateUser, logout };
};

export default useUser;
