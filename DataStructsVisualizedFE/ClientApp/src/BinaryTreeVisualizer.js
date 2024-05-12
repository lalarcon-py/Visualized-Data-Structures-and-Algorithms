import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Tree from 'react-d3-tree';

const BinaryTreeVisualizer = () => {
    const [binaryTree, setBinaryTree] = useState(null);

    useEffect(() => {
        fetchBinaryTree();
    }, []);

    const fetchBinaryTree = async () => {
        try {
            const response = await axios.get('api/binarytree');
            setBinaryTree(response.data);
        } catch (error) {
            console.error('Error fetching binary tree:', error);
        }
    };

    const renderBinaryTree = () => {
        if (!binaryTree) {
            return <div>Loading...</div>;
        }

        return (
            <Tree data={binaryTree} />
        );
    };
};

export default BinaryTreeVisualizer;