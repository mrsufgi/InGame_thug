git config --global alias.rm-symlink '!__git_rm_symlink(){
    git checkout -- "$1"
    link=$(echo "$1")
    POS=$'\''/'\''
    DOS=$'\''\\\\'\''
    doslink=${link//$POS/$DOS}
    dest=$(dirname "$link")/$(cat "$link")
    dosdest=${dest//$POS/$DOS}
    if [ -f "$dest" ]; then
        rm -f "$link"
        cmd //C mklink //H "$doslink" "$dosdest"
    elif [ -d "$dest" ]; then
        rm -f "$link"
        cmd //C mklink //J "$doslink" "$dosdest"
    else
        echo "ERROR: Something went wrong when processing $1 . . ."
        echo "       $dest may not actually exist as a valid target."
    fi
}; __git_rm_symlink "$1"'

git config --global alias.rm-symlinks '!__git_rm_symlinks(){
    for symlink in `git ls-files -s | egrep "^120000" | cut -f2`; do
        git rm-symlink "$symlink"
        git update-index --assume-unchanged "$symlink"
    done
}; __git_rm_symlinks'

git config --global alias.add-symlink '!__git_add_symlink(){
    dst=$(echo "$2")/../$(echo "$1")
    if [ -e "$dst" ]; then
        hash=$(echo "$1" | git hash-object -w --stdin)
        git update-index --add --cacheinfo 120000 "$hash" "$2"
        git checkout -- "$2"
    else
        echo "ERROR: Target $dst does not exist!"
        echo "       Not creating invalid symlink."
    fi
}; __git_add_symlink "$1" "$2"'

git config --global alias.checkout-symlinks '!__git_checkout_symlinks(){
    POS=$'\''/'\''
    DOS=$'\''\\\\'\''
    for symlink in `git ls-files -s | egrep "^120000" | cut -f2`; do
        git update-index --no-assume-unchanged "$symlink"
        dossymlink=${symlink//$POS/$DOS}
        cmd //C rmdir //Q "$dossymlink" 2>/dev/null
        git  checkout -- "$symlink"
        echo "Restored git symlink $symlink <<===>> `cat $symlink`"
    done
}; __git_checkout_symlinks'