import React, { useState, useEffect } from 'react';
import { getUsers, createUser } from './api';

const Users = () => {
    const [users, setUsers] = useState([]);
    const [name, setName] = useState('');
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');

    useEffect(() => {
        const fetchUsers = async () => {
            const data = await getUsers();
            setUsers(data);
        };

        fetchUsers();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newUser = { name, username, email };
        const createdUser = await createUser(newUser);
        setUsers([...users, createdUser]);
        setName('');
        setUsername('');
        setEmail('');
    };

    return (
        <div>
            <h1>Users</h1>
            <ul>
                {users.map((user) => (
                    <li key={user.userID}>{user.name} - {user.username} - {user.email}</li>
                ))}
            </ul>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <button type="submit">Create User</button>
            </form>
        </div>
    );
};

export default Users;
